using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Muscles
{
    public class MuscleController : Controller
    {
        private readonly BarnamaConntext _context;

        public MuscleController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: Muscle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muscles.ToListAsync());
        }
       [HttpGet]
        public List<Muscle> GetMuscles () {
            return _context.Muscles.ToList ();
        }
        // GET: Muscle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // GET: Muscle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muscle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl")] Muscle muscle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muscle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscle);
        }

        // GET: Muscle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }
            return View(muscle);
        }

        // POST: Muscle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl")] Muscle muscle)
        {
            if (id != muscle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muscle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuscleExists(muscle.Id))
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
            return View(muscle);
        }

        // GET: Muscle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // POST: Muscle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muscle = await _context.Muscles.FindAsync(id);
            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuscleExists(int id)
        {
            return _context.Muscles.Any(e => e.Id == id);
        }
    }
}
