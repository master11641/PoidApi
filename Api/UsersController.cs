using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route ("Api")]
public class UsersApiController : ControllerBase {
    private IUserService _userService;
    private readonly HttpClient HttpClient;
    private BarnamaConntext _context;
    public UsersApiController (IUserService userService, BarnamaConntext context) {
        _userService = userService;
        _context = context;
        HttpClient = new HttpClient ();
    }

    [Authorize]
    [HttpGet ("getall")]
    public IActionResult GetAll () {
        var users = _userService.GetAll ();
        return Ok (users);
    }

    [Authorize]
    // [HotChocolate.AspNetCore.Authorization.Authorize()]
    [HttpGet ("getcurrentuser")]
    public IActionResult GetCurrentUser () {
        var clims = User.Claims;
        string authHeader = Request.Headers["Authorization"];
        authHeader = authHeader.Replace ("Bearer ", "");
        var username = _userService.GetUserName (authHeader);
        return Ok (_userService.GetByUserName (username));
    }

    [HttpPost ("Register")]
    public IActionResult Register (String phoneNumber, String name, String family, String introducedUserPhone) {
        var user = _userService.GetByUserName (phoneNumber);
        var rand = new Random ();
        var uid = rand.Next (1000, 9999);
        String newPassword = uid.ToString ();
        // string token = "";
        if (user == null) {
            User addUser = new User () {
            PhoneNumber = phoneNumber,
            Password = newPassword,
            RegisterDate = DateTime.Now,
            Name = name,
            Family = family,

            };
            if (introducedUserPhone != null) {
                var userIntroduce = _context.Users.Where (x => x.PhoneNumber == introducedUserPhone).ToList ();
                if (userIntroduce.Count != 0 && introducedUserPhone != null) {
                    addUser.IntroducedUserPhone = introducedUserPhone;
                    Discount discount = new Discount ();
                    discount.Title = "تخفیف معرف";
                    discount.Percentage = 5;
                    discount.Code = "Planiverse" + rand.Next (1000, 9999).ToString ();
                    discount.UserNames = introducedUserPhone;
                    _context.Discounts.Add (discount);
                    new SmsUtil ().Send (introducedUserPhone, String.Format ("کد تخفیف {0} برای استفاده در نرم افزار پلنیورس برای شما ایجاد گردید .", discount.Code)); //کد تخفیف برای کاربر ارسال گردد
                }
            }

            _context.Users.Add (addUser);
            _context.SaveChanges ();
            user = addUser;
        } else {
            return NotFound ("شماره همراه از قبل وجود دارد");
            // user.Name = name;
            // user.Family = family;
            // user.Password = newPassword;
            // _context.SaveChanges ();
        }
       // Field userField = _context.Fields.Where (x => x.Id == user.FieldId).Include (x => x.Grade).FirstOrDefault ();
        UserDetails userDetails = new UserDetails {
            Id = user.Id,
            Family = user.Family,
            FcmToken = "",
         
           // FieldTitle = userField?.Title,
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Password = "",
           // GradeId = userField?.GradeId,
           //GradeTitle = userField?.Grade?.Title

        };
        return Ok (userDetails);
    }

    [HttpPost ("GetUserByPhone")]
    public IActionResult GetUserByPhone (string phoneNumber) {
        var user = _userService.GetByUserName (phoneNumber);
        if (user == null) {
            return NotFound ();
        }
        //Field userField = _context.Fields.Where (x => x.Id == user.FieldId).Include (x => x.Grade).FirstOrDefault ();
        // if (userField == null) {
        //     return NotFound ();
        // }
        var users = _context.Users.Include (x => x.UserRoles).Where (x => x.UserRoles.Count > 0).ToList ();
        UserDetails userDetails = new UserDetails {
            Id = user.Id,
            Family = user.Family,
            FcmToken = "",
          
            //FieldTitle = userField?.Title,
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Password = "",
            // GradeId = userField?.GradeId,
            // GradeTitle = userField?.Grade?.Title,
        

        };
        return Ok (userDetails);
    }

    [HttpPost ("ConfirmMobileNumber")]
    public ActionResult ConfirmMobileNumber (string phone) {
        var user = _userService.GetByUserName (phone);
        if (user == null) {
            return NotFound ();
        }
        var rand = new Random ();
        var uid = rand.Next (1000, 9999);
        String newPassword = uid.ToString ();
        user.Password = newPassword;
        _context.SaveChanges ();
        // var sender = "10008000880055";
        // var receptor = phone;
        // var message = String.Format ("Planiverse Code :  {0}", user.Password);
        // var api = new Kavenegar.KavenegarApi ("33735370676E55562B46367761763335756852594966616161416E37387A683547573851336E2F465379513D");
        // api.Send (sender, receptor, message);
        //********************
        // var request = new HttpRequestMessage (HttpMethod.Get,
        //     String.Format ("https://api.kavenegar.com/v1/33735370676E55562B46367761763335756852594966616161416E37387A683547573851336E2F465379513D/verify/lookup.json?receptor={1}&token={0}&template=verify", user.Password, phone));

        // var response = HttpClient.SendAsync (request);
        new SmsUtil ().Send (phone, user.Password);
        return Ok (user.Password);
    }

    // public async Task<ActionResult> SendSmsAsync (string phone) {

    //     var request = new HttpRequestMessage (HttpMethod.Get,
    //         "https://api.kavenegar.com/v1/33735370676E55562B46367761763335756852594966616161416E37387A683547573851336E2F465379513D/verify/lookup.json?receptor=09155344405&token=852596&template=verify");
    //     string result = "";
    //     var response = HttpClient.SendAsync (request);
    //     if (response.IsCompletedSuccessfully) {
    //         result = await response.Result.Content.ReadAsStringAsync ();
    //     }
    //     return Ok (result);
    // }

    [HttpPost ("login")]
    public async Task<IActionResult> Login (AuthenticateRequest request) {
        var user = _userService.GetByUserName (request.Username);
        if (user != null) {
            // User addUser = new User () {
            // PhoneNumber = request.Username,
            // Password = request.Password
            // };
            // _context.SaveChanges ();
            try {
                string token = await _userService.AuthenticateAsync (request);
                return Ok (token);
            } catch {
                //   return NotFound ();
            }
        }

        return NotFound ();
    }

    [HttpPost ("setField")]
    public IActionResult setField (int fieldId, int userId) {
        //حذف کلیه اطلاعات قبلی کاربر در صورتی که تغییر رشته دهد

        User user = _userService.GetById (userId);
       
        // if (user.FieldId != fieldId) {
        //     List<Lesson> lessons = _context.Lessons.Where (x => x.UserName == user.PhoneNumber).ToList ();
        //     if (lessons.Count != 0) {
        //         _context.Lessons.RemoveRange (lessons);
        //     }
        //     List<Book> books = _context.Books.Where (x => x.UserId == userId).Include(x=>x.Partitions).ToList ();
        //     if (books.Count != 0) {              
        //         _context.Books.RemoveRange(books);
        //         _context.Partitions.RemoveRange(books.SelectMany(x=>x.Partitions));
        //     }
        //     _context.SaveChanges ();
        // }

        var users = _context.Users.Include (x => x.UserRoles).Where (x => x.UserRoles.Count > 0).ToList ();

       
        _context.Users.Attach (user);
        _context.SaveChanges ();
       // Field field = _context.Fields.Include (x => x.Grade).FirstOrDefault (x => x.Id == fieldId);
        UserDetails ud = new UserDetails {
            Family = user.Family,
            FcmToken = user.FcmToken,
            
           
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            PhoneNumber = user.Password,
           

        };
        return Ok (ud);
    }

    [HttpPost ("SetFcmToken")]
    public IActionResult SetFcmToken (string fcmToken, int userId) {
        User user = _userService.GetById (userId);
        user.FcmToken = fcmToken;
        _context.Users.Attach (user);
        _context.SaveChanges ();
        return Ok (user.Id);
    }

    [HttpGet ("GetAdvisers")]

    public ActionResult GetAdvisers () {
        var users = _context.Users.Include (x => x.UserRoles).Where (x => x.UserRoles.Count > 0).Select (x => new { x.Name, x.Family, x.Id, x.ImageProfileUrl, x.PhoneNumber }).ToList ();
        return Ok (users);
    }

}