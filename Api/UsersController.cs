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
        var uid = rand.Next (10000, 99999);
        //String newPassword = uid.ToString ();
        String newPassword = "12345";
        // string token = "";
        if (user == null) {
            User addUser = new User () {
            PhoneNumber = phoneNumber,
            Password = newPassword,
            RegisterDate = DateTime.Now,
            Name = name,
            Family = family,
            ImageProfileUrl = "noimage.png"

            };
            // if (introducedUserPhone != null) {
            //     var userIntroduce = _context.Users.Where (x => x.PhoneNumber == introducedUserPhone).ToList ();
            //     if (userIntroduce.Count != 0 && introducedUserPhone != null) {
            //         addUser.IntroducedUserPhone = introducedUserPhone;
            //         Discount discount = new Discount ();
            //         discount.Title = "تخفیف معرف";
            //         discount.Percentage = 5;
            //         discount.Code = "Planiverse" + rand.Next (1000, 9999).ToString ();
            //         discount.UserNames = introducedUserPhone;
            //         _context.Discounts.Add (discount);
            //         new SmsUtil ().Send (introducedUserPhone, String.Format ("کد تخفیف {0} برای استفاده در نرم افزار پلنیورس برای شما ایجاد گردید .", discount.Code)); //کد تخفیف برای کاربر ارسال گردد
            //     }
            // }

            _context.Users.Add (addUser);
            _context.SaveChanges ();

            user = addUser;
            ServicePackage freePackage = _context.ServicePackages.Where (x => x.Price == 0).FirstOrDefault ();
            _context.Invoices.Add (new Invoice {
                Amount = 0,
                    PaymentDate = DateTime.Now,
                    IsConfirm = true,
                    RegisterDate = DateTime.Now,
                    ServicePackageId = freePackage.Id,
                    UserId = user.Id,
                    RefId = "free package",
                    Authority = "free package",
            });
            _context.SaveChanges ();
        } else {
            // return NotFound ("شماره همراه از قبل وجود دارد");
            user.Name = name;
            user.Family = family;
            user.Password = newPassword;
            _context.SaveChanges ();
        }
        // Field userField = _context.Fields.Where (x => x.Id == user.FieldId).Include (x => x.Grade).FirstOrDefault ();
        UserDetails userDetails = new UserDetails {
            Id = user.Id,
            Family = user.Family,
            FcmToken = "",

            // FieldTitle = userField?.Title,
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Password = newPassword,
            ImageProfileUrl = user.ImageProfileUrl
            // GradeId = userField?.GradeId,
            //GradeTitle = userField?.Grade?.Title

        };
        return Ok (userDetails);
    }

    [HttpPost ("ChangeUserProfileImage")]
    public IActionResult ChangeUserProfileImage (int userId, string imageUrl) {
        var user = _context.Users.Find (userId);
        if (user == null) {
            return BadRequest ("کاربری شما نامعتبر است");
        }
        user.ImageProfileUrl = imageUrl;
        _context.SaveChanges ();
        return Ok (imageUrl);
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
        //  String newPassword = uid.ToString ();
        String newPassword = "12345";
        user.Password = newPassword;
        _context.SaveChanges ();
        new SmsUtil ().Send (phone, user.Password);
        return Ok (user.Password);
    }

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

        return BadRequest ("اطلاعات وارد شده اشتباه است .");
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

    [HttpGet ("GetReminderServiceInDate")]

    public ActionResult GetReminderServiceInDate (int userId) {
        var currentDiet = _context.Diets.Include (x => x.Weights).Include (x => x.FatPartDiets)
            .Include (x => x.SicknessDiets).ThenInclude (x => x.Sickness)
            .Where (x => x.UserId == userId ).OrderByDescending (x => x.Id).FirstOrDefault ();
        var invoice = _context.Invoices.Include (x => x.ServicePackage).Where (x => x.UserId == userId && x.IsConfirm == true).OrderByDescending(x=>x.Id).FirstOrDefault ();
        if (invoice == null) {
            return Ok (0);
        }
        var diffInDays = (DateTime.Now - (DateTime) invoice.PaymentDate).Days;
        int remindInDays = invoice.ServicePackage.ExpireAfterBuyInDays - diffInDays;
        //    //
        double weight = currentDiet.Weights.LastOrDefault ().UserWeight;
        var bmi = weight / ((currentDiet.Height / 100) * (currentDiet.Height / 100));
        string description = "";
        if (bmi < 18.5) {
            description = "لاغر-دچار کمبود وزن";
        } else if (bmi > 18.5 && bmi < 25) {
            description = "وزن نرمال";
        } else if (bmi >= 25 && bmi < 30) {
            description = "اضافه وزن";
        } else if (bmi >= 30 && bmi < 35) {
            description = "چاقی درجه یک";
        } else if (bmi >= 35 && bmi < 40) {
            description = "چاقی درجه دو";
        } else {
            description = "چاقی درجه سه";
        }
        return Ok (new {
            remindInDays = remindInDays, allInDays = invoice.ServicePackage.ExpireAfterBuyInDays, description = description, diseases = currentDiet.SicknessDiets.Select (x => x.Sickness.Title)

        });
    }

}