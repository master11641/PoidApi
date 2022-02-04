using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Nutrients {
    public class NutrientController : Controller {
        private readonly BarnamaConntext _context;

        public NutrientController (BarnamaConntext context) {
            _context = context;
        }

        [HttpGet]
        public List<Nutrient> GetNutrients () {
            return _context.Nutrients.ToList ();
        }
        // GET: Nutrient
        public async Task<IActionResult> Index () {
            return View (await _context.Nutrients.ToListAsync ());
        }

        // GET: Nutrient/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nutrient = await _context.Nutrients
                .FirstOrDefaultAsync (m => m.Id == id);
            if (nutrient == null) {
                return NotFound ();
            }

            return View (nutrient);
        }

        // GET: Nutrient/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Nutrient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,ImageUrl,IsMicro")] Nutrient nutrient) {
            if (ModelState.IsValid) {
                _context.Add (nutrient);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (nutrient);
        }

        // GET: Nutrient/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nutrient = await _context.Nutrients.FindAsync (id);
            if (nutrient == null) {
                return NotFound ();
            }
            return View (nutrient);
        }

        // POST: Nutrient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Id,Title,ImageUrl,IsMicro")] Nutrient nutrient) {
            if (id != nutrient.Id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (nutrient);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!NutrientExists (nutrient.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (nutrient);
        }

        // GET: Nutrient/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var nutrient = await _context.Nutrients
                .FirstOrDefaultAsync (m => m.Id == id);
            if (nutrient == null) {
                return NotFound ();
            }

            return View (nutrient);
        }

        // POST: Nutrient/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var nutrient = await _context.Nutrients.FindAsync (id);
            _context.Nutrients.Remove (nutrient);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool NutrientExists (int id) {
            return _context.Nutrients.Any (e => e.Id == id);
        }
    }
}