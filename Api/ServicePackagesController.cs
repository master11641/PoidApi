using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class ServicePackagesController : Controller {
        private BarnamaConntext _context;
        public ServicePackagesController (BarnamaConntext context) {
            _context = context;;
        }
        ///پکیج هایی را بر می گرداند که مربوط به بازار نباشند و کد تخفیف هم نداشته باشند
        [HttpGet ("GetPackages")]
        public IActionResult Index () {
            var barnamaConntext = _context.ServicePackages.Include (x => x.Discount).Where (x => String.IsNullOrWhiteSpace (x.BazarProductId) && String.IsNullOrWhiteSpace (x.Discount.Code));
            return Ok (barnamaConntext.ToList ());
        }
        ///در صورتی که کد تخفیف درست باشد آن را روی پکیج لحاظ می کند
        [HttpGet ("CalcDiscount")]
        public IActionResult CalcDiscount (string code, int packageId, string userPhone) {
            //  var service = _context.ServicePackages.Include (x => x.Discount).Where (x => x.Discount.Code == code && x.Id == packageId).FirstOrDefault ();
            var service = _context.ServicePackages.Where (x => x.Id == packageId).FirstOrDefault ();
            var Discount = _context.Discounts.Where (x => x.Code == code).FirstOrDefault ();
            if (Discount == null) {
                return BadRequest ("کد تخفیف اشتباه است");
            }
            if (Discount.UserNames != null) {
                if ((Discount.UserNames.Count () > 0 && !Discount.UserNames.Contains (userPhone)) || service == null) {
                    return BadRequest ("کد تخفیف اشتباه است");
                }
            }

            return Ok (service.Price * Discount.Percentage / 100);
        }

        //=======CafeBazar Methods==========
        [HttpGet ("GetBazarPackages")]
        public IActionResult GetBazarPackages () {
            var barnamaConntext = _context.ServicePackages.Include (x => x.Discount).Where (x => !String.IsNullOrWhiteSpace (x.BazarProductId));
            return Ok (barnamaConntext.ToList ());
        }
        ///در صورتی که کد تخفیف درست باشد شناسه محصول تخفیف خورده را در بازار بر می گرداند
        [HttpGet ("CalcBazarDiscount")]
        public IActionResult CalcBazarDiscount (string code, int packageId, string userPhone) {
            var service = _context.ServicePackages.Include (x => x.Discount).Where (x => x.Discount.Code == code && x.Id == packageId).FirstOrDefault ();
            if (service == null) {
                return BadRequest ("کد تخفیف اشتباه است");
            }
            if (!String.IsNullOrWhiteSpace (service.Discount.UserNames) && service.Discount.UserNames.Contains (userPhone) == false) {
                return BadRequest ("تخفیف برای شما اعمال نمی شود");
            }
            return Ok (service.Discount.BazarProductId);
        }

    }
}