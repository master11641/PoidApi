using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Allergies
{
    public class AllergyController : Controller
    {
        private readonly BarnamaConntext _context;

        public AllergyController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: Allergy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Allergies.ToListAsync());
        }

        // GET: Allergy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // GET: Allergy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allergy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergy);
        }

        // GET: Allergy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return View(allergy);
        }

        // POST: Allergy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergyExists(allergy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allergy);
        }

        // GET: Allergy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // POST: Allergy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergy = await _context.Allergies.FindAsync(id);
            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergyExists(int id)
        {
            return _context.Allergies.Any(e => e.Id == id);
        }
    }
}
