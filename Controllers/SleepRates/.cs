using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.SleepRates
{
    public class SleepRateController : Controller
    {
        private readonly BarnamaConntext _context;

        public SleepRateController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: SleepRate
        public async Task<IActionResult> Index()
        {
            return View(await _context.SleepRates.ToListAsync());
        }

        // GET: SleepRate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepRate = await _context.SleepRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepRate == null)
            {
                return NotFound();
            }

            return View(sleepRate);
        }

        // GET: SleepRate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SleepRate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] SleepRate sleepRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleepRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sleepRate);
        }

        // GET: SleepRate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepRate = await _context.SleepRates.FindAsync(id);
            if (sleepRate == null)
            {
                return NotFound();
            }
            return View(sleepRate);
        }

        // POST: SleepRate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] SleepRate sleepRate)
        {
            if (id != sleepRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleepRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleepRateExists(sleepRate.Id))
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
            return View(sleepRate);
        }

        // GET: SleepRate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleepRate = await _context.SleepRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sleepRate == null)
            {
                return NotFound();
            }

            return View(sleepRate);
        }

        // POST: SleepRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleepRate = await _context.SleepRates.FindAsync(id);
            _context.SleepRates.Remove(sleepRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleepRateExists(int id)
        {
            return _context.SleepRates.Any(e => e.Id == id);
        }
    }
}
