using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class DietController : Controller {
        private BarnamaConntext _context;
        public DietController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetUserDiet")]
        public IActionResult GetUserDiet (int userId) {
            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete != true).FirstOrDefault ();
            return Ok (diet);
        }

        [HttpPost ("GetBmiUser")]
        public IActionResult GetBmiUser (int userId) {
            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
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
            var result = new {
                bmi = bmi,
                description = description
            };
            return Ok (result);
        }

        [HttpPost ("GetFatUser")]
        public IActionResult GetFatUser (int userId) {

            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).Include (x => x.User).Include (x => x.Gender).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
            string description = "";
            int g = 0;
            if (diet.Gender.Title.Contains ("مرد")) {
                g = 1; //مرد
            } else {
                g = 0; //زن
            }
            var fat = (1.2 * bmi) + (0.23 * diet.Age) - (10.8 * g) - 5.4;
            if (g == 1) {
                if (fat >= 20 && fat <= 25) {
                    description = "درصد چربی بدن زیاد بوده و احتمال خطر سلامت متابولیک و چاقی وجود دارد .";
                }
            } else {
                if (fat >= 25 && fat <= 32) {
                    description = "درصد چربی بدن زیاد بوده و احتمال خطر سلامت متابولیک و چاقی وجود دارد .";
                }
            }

            var result = new {
                fat = fat,
                description = description
            };
            return Ok (result);
        }

        [HttpPost ("GetCalleryUser")]
        public IActionResult GetCalleryUser (int userId) {

            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).Include (x => x.User).Include (x => x.Gender).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
            string description = "";
            double g = 0;

            if (diet.Gender.Title.Contains ("مرد")) {
                g = 1; //مرد
            } else {
                g = 0.95; //زن
            }
            double callery = 0;
            int coefficient = 0;
            if (diet.Age < 30) {
                coefficient = 21;
            } else if (diet.Age < 50) {
                coefficient = 23;
            } else {
                coefficient = 24;
            }
            if (bmi < 25) {
                callery = (double) (1.1 * 1.3 * 24 * g * diet.Weight);
            } else {
               double weightNormal = (double)(coefficient * ((diet.Height / 100) * (diet.Height / 100)));
               double ibw = (double)(weightNormal + ((diet.Weight-weightNormal)*0.25));
               callery = 1.1*1.3*24*g*ibw;
            }

            var result = new {
                fat = callery,
                description = description
            };
            return Ok (result);
        }
    }
}