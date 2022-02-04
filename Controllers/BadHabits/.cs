using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.BadHabits
{
    public class BadHabitController : Controller
    {
        private readonly BarnamaConntext _context;

        public BadHabitController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: BadHabit
        public async Task<IActionResult> Index()
        {
            return View(await _context.BadHabits.ToListAsync());
        }

        // GET: BadHabit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badHabit = await _context.BadHabits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (badHabit == null)
            {
                return NotFound();
            }

            return View(badHabit);
        }

        // GET: BadHabit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BadHabit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] BadHabit badHabit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(badHabit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(badHabit);
        }

        // GET: BadHabit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badHabit = await _context.BadHabits.FindAsync(id);
            if (badHabit == null)
            {
                return NotFound();
            }
            return View(badHabit);
        }

        // POST: BadHabit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] BadHabit badHabit)
        {
            if (id != badHabit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(badHabit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BadHabitExists(badHabit.Id))
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
            return View(badHabit);
        }

        // GET: BadHabit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var badHabit = await _context.BadHabits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (badHabit == null)
            {
                return NotFound();
            }

            return View(badHabit);
        }

        // POST: BadHabit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var badHabit = await _context.BadHabits.FindAsync(id);
            _context.BadHabits.Remove(badHabit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BadHabitExists(int id)
        {
            return _context.BadHabits.Any(e => e.Id == id);
        }
    }
}
