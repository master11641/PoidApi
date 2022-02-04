using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Units {
    public class UnitController : Controller {
        private readonly BarnamaConntext _context;

        public UnitController (BarnamaConntext context) {
            _context = context;
        }

        [HttpGet]
        public List<Unit> GetUnits () {
            return _context.Units.ToList ();
        }
        // GET: Unit
        public async Task<IActionResult> Index () {
            return View (await _context.Units.ToListAsync ());
        }

        [HttpGet]
        public List<Unit> GetAllUnits () {
            return _context.Units.ToList ();
        }
        // GET: Unit/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var unit = await _context.Units
                .FirstOrDefaultAsync (m => m.Id == id);
            if (unit == null) {
                return NotFound ();
            }

            return View (unit);
        }

        // GET: Unit/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Unit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,ImageUrl")] Unit unit) {
            if (ModelState.IsValid) {
                _context.Add (unit);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (unit);
        }

        // GET: Unit/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var unit = await _context.Units.FindAsync (id);
            if (unit == null) {
                return NotFound ();
            }
            return View (unit);
        }

        // POST: Unit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("Id,Title,ImageUrl")] Unit unit) {
            if (id != unit.Id) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (unit);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!UnitExists (unit.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (unit);
        }

        // GET: Unit/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var unit = await _context.Units
                .FirstOrDefaultAsync (m => m.Id == id);
            if (unit == null) {
                return NotFound ();
            }

            return View (unit);
        }

        // POST: Unit/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var unit = await _context.Units.FindAsync (id);
            _context.Units.Remove (unit);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool UnitExists (int id) {
            return _context.Units.Any (e => e.Id == id);
        }
    }
}