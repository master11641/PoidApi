using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Barnama.Controllers {
     [Authorize(UserInRole ="admin")]
    public class ServicePackageController : Controller {
        private readonly BarnamaConntext _context;

        public ServicePackageController (BarnamaConntext context) {
            _context = context;
        }

        // GET: ServicePackage
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.ServicePackages.Include (s => s.Discount);
            return View (await barnamaConntext.ToListAsync ());
        }

        // GET: ServicePackage/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var servicePackage = await _context.ServicePackages
                .Include (s => s.Discount)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (servicePackage == null) {
                return NotFound ();
            }

            return View (servicePackage);
        }

        // GET: ServicePackage/Create
        public IActionResult Create () {
            ViewData["DiscountId"] = new SelectList (_context.Discounts, "Id", "Id");
            return View ();
        }

        // POST: ServicePackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,Desciption,ImageUrl,Price,StartTime,EndTime,IsAdviserType,ExpireAfterBuyInDays,DiscountId,BazarProductId")] ServicePackage servicePackage) {
           
                _context.Add (servicePackage);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
          
           // ViewData["DiscountId"] = new SelectList (_context.Discounts, "Id", "Id", servicePackage.DiscountId);
           // return View (servicePackage);
        }

        // GET: ServicePackage/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var servicePackage = await _context.ServicePackages.FindAsync (id);
            if (servicePackage == null) {
                return NotFound ();
            }
            ViewData["DiscountId"] = new SelectList (_context.Discounts, "Id", "Id", servicePackage.DiscountId);
            return View (servicePackage);
        }

        // POST: ServicePackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int Id, string Title, string Desciption, string ImageUrl, int Price, DateTime? StartTime, DateTime? EndTime, bool IsAdviserType, int ExpireAfterBuyInDays, Int32? DiscountId, string BazarProductId) {
            var package = _context.ServicePackages.Find (Id);
            if (package == null) {
                return NotFound ();
            }

            //if (ModelState.IsValid) {
               
                package.Title = Title;
                package.Desciption = Desciption;
                package.ImageUrl = ImageUrl;
                package.DiscountId = DiscountId;
                package.StartTime=StartTime;
                package.EndTime=EndTime;
                package.Price=Price;
                package.IsAdviserType=IsAdviserType;

                _context.Update (package);
                await _context.SaveChangesAsync ();

                return RedirectToAction (nameof (Index));
           // }
           // ViewData["DiscountId"] = new SelectList (_context.Discounts, "Id", "Id", package.DiscountId);
           // return View (package);
        }

        // GET: ServicePackage/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var servicePackage = await _context.ServicePackages
                .Include (s => s.Discount)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (servicePackage == null) {
                return NotFound ();
            }

            return View (servicePackage);
        }

        // POST: ServicePackage/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var servicePackage = await _context.ServicePackages.FindAsync (id);
            _context.ServicePackages.Remove (servicePackage);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool ServicePackageExists (int id) {
            return _context.ServicePackages.Any (e => e.Id == id);
        }
    }
}