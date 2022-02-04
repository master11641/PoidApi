using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Proteins
{
    public class ProteinController : Controller
    {
        private readonly BarnamaConntext _context;

        public ProteinController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: Protein
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proteins.ToListAsync());
        }

        // GET: Protein/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protein = await _context.Proteins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protein == null)
            {
                return NotFound();
            }

            return View(protein);
        }

        // GET: Protein/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Protein/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl")] Protein protein)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protein);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protein);
        }

        // GET: Protein/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protein = await _context.Proteins.FindAsync(id);
            if (protein == null)
            {
                return NotFound();
            }
            return View(protein);
        }

        // POST: Protein/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl")] Protein protein)
        {
            if (id != protein.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protein);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProteinExists(protein.Id))
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
            return View(protein);
        }

        // GET: Protein/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protein = await _context.Proteins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protein == null)
            {
                return NotFound();
            }

            return View(protein);
        }

        // POST: Protein/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protein = await _context.Proteins.FindAsync(id);
            _context.Proteins.Remove(protein);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProteinExists(int id)
        {
            return _context.Proteins.Any(e => e.Id == id);
        }
    }
}
