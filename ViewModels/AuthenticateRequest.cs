using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
    {
        [Display(Name="نام کاربری")]
        [Required(ErrorMessage="تکمیل نام کاربری الزامی است")]
        public string Username { get; set; }

       [Required(ErrorMessage="تکمیل پسورد الزامی است")]
         [Display(Name="پسورد")]
        public string Password { get; set; }
    }