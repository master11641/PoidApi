using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.WaterRates
{
    public class WaterRateController : Controller
    {
        private readonly BarnamaConntext _context;

        public WaterRateController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: WaterRate
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterRates.ToListAsync());
        }

        // GET: WaterRate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterRate = await _context.WaterRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterRate == null)
            {
                return NotFound();
            }

            return View(waterRate);
        }

        // GET: WaterRate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterRate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] WaterRate waterRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterRate);
        }

        // GET: WaterRate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterRate = await _context.WaterRates.FindAsync(id);
            if (waterRate == null)
            {
                return NotFound();
            }
            return View(waterRate);
        }

        // POST: WaterRate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] WaterRate waterRate)
        {
            if (id != waterRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterRateExists(waterRate.Id))
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
            return View(waterRate);
        }

        // GET: WaterRate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterRate = await _context.WaterRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterRate == null)
            {
                return NotFound();
            }

            return View(waterRate);
        }

        // POST: WaterRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterRate = await _context.WaterRates.FindAsync(id);
            _context.WaterRates.Remove(waterRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterRateExists(int id)
        {
            return _context.WaterRates.Any(e => e.Id == id);
        }
    }
}
