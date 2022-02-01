using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Adver.Helpers;
// using Adver.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
public interface IUserService {
    //  AuthenticateResponse Authenticate (AuthenticateRequest model);

    Task<string> AuthenticateAsync (AuthenticateRequest model) ;
    
    IEnumerable<User> GetAll ();
    User GetById (int id);
    User GetByUserName (String username);
    string GetUserName (string token);
}

public class UserService : IUserService {
    private BarnamaConntext _context;
    private List<User> _users;

    private readonly AppSettings _appSettings;
    public UserService (BarnamaConntext context, IOptions<AppSettings> appSettings) {
        _context = context;
        _appSettings = appSettings.Value;
        _users = _context.Users.Include(x=>x.UserRoles).ThenInclude(x=>x.Role).ToList ();
    }


    public IEnumerable<User> GetAll () {
        return _users;
    }

    public User GetById (int id) {
        return _users.FirstOrDefault (x => x.Id == id);


    }

    // helper methods

    private string generateJwtToken (User user) {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler ();
        var key = Encoding.ASCII.GetBytes (_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity (new [] {
            new Claim (ClaimTypes.Name, user.PhoneNumber.ToString ()),
            new Claim ("id", user.Id.ToString ())
            }),
            Expires = DateTime.UtcNow.AddDays (365),
            SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken (tokenDescriptor);
        return tokenHandler.WriteToken (token);
    }


    public string GetUserName (string token) {

        string secret = _appSettings.Secret;
        var key = new SymmetricSecurityKey (
            Encoding.UTF8.GetBytes ("secretsecretsecret"));
        var handler = new JwtSecurityTokenHandler ();
        var validations = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidAudience = "audience",
            ValidIssuer = "issuer",
        };
        var claims = handler.ValidateToken (token, validations, out var tokenSecure);
        return claims.Identity.Name;
    }
    public Task<string> AuthenticateAsync (AuthenticateRequest model) {
        var roles = new List<string> ();
        var user = _users.SingleOrDefault (x => x.PhoneNumber == model.Username && x.Password == model.Password);
        if (user == null) {
            throw new AuthenticationException ();           
           // return Task.FromResult ("");
        }
        // if (user.XUserTitle.Contains ("مدیر") || user.XUserTitle.Contains ("admin")) {
        //     roles.Add ("admin");
        // }
        if (roles.Count == 0) {
            roles.Add ("user");
        }
        return Task.FromResult (GenerateAccessToken (user, roles.ToArray ()));

    }
    private string GenerateAccessToken (User user, string[] roles) {
        var key = new SymmetricSecurityKey (
            Encoding.UTF8.GetBytes ("secretsecretsecret"));

        var claims = new List<Claim> {
            new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
            new Claim (ClaimTypes.Name, user.PhoneNumber.ToString ())
        };

        claims = claims.Concat (roles.Select (role => new Claim (ClaimTypes.Role, role))).ToList ();
        var signingCredentials = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken (
            "issuer",
            "audience",
            claims,
            expires : DateTime.Now.AddDays (90),
            signingCredentials : signingCredentials);

        return new JwtSecurityTokenHandler ().WriteToken (token);
    }

    public User GetByUserName (string username) {
        return _users.FirstOrDefault (x => x.PhoneNumber == username);
    }
}