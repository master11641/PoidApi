using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.FatParts
{
    public class FatPartController : Controller
    {
        private readonly BarnamaConntext _context;

        public FatPartController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: FatPart
        public async Task<IActionResult> Index()
        {
            return View(await _context.FatParts.ToListAsync());
        }

        // GET: FatPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatPart = await _context.FatParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatPart == null)
            {
                return NotFound();
            }

            return View(fatPart);
        }

        // GET: FatPart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FatPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl")] FatPart fatPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fatPart);
        }

        // GET: FatPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatPart = await _context.FatParts.FindAsync(id);
            if (fatPart == null)
            {
                return NotFound();
            }
            return View(fatPart);
        }

        // POST: FatPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl")] FatPart fatPart)
        {
            if (id != fatPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FatPartExists(fatPart.Id))
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
            return View(fatPart);
        }

        // GET: FatPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fatPart = await _context.FatParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatPart == null)
            {
                return NotFound();
            }

            return View(fatPart);
        }

        // POST: FatPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fatPart = await _context.FatParts.FindAsync(id);
            _context.FatParts.Remove(fatPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FatPartExists(int id)
        {
            return _context.FatParts.Any(e => e.Id == id);
        }
    }
}
