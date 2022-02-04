using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.ActivityRates
{
    public class ActivityRateController : Controller
    {
        private readonly BarnamaConntext _context;

        public ActivityRateController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: ActivityRate
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityRates.ToListAsync());
        }

        // GET: ActivityRate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityRate = await _context.ActivityRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityRate == null)
            {
                return NotFound();
            }

            return View(activityRate);
        }

        // GET: ActivityRate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityRate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] ActivityRate activityRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityRate);
        }

        // GET: ActivityRate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityRate = await _context.ActivityRates.FindAsync(id);
            if (activityRate == null)
            {
                return NotFound();
            }
            return View(activityRate);
        }

        // POST: ActivityRate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] ActivityRate activityRate)
        {
            if (id != activityRate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityRateExists(activityRate.Id))
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
            return View(activityRate);
        }

        // GET: ActivityRate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityRate = await _context.ActivityRates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityRate == null)
            {
                return NotFound();
            }

            return View(activityRate);
        }

        // POST: ActivityRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityRate = await _context.ActivityRates.FindAsync(id);
            _context.ActivityRates.Remove(activityRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityRateExists(int id)
        {
            return _context.ActivityRates.Any(e => e.Id == id);
        }
    }
}
