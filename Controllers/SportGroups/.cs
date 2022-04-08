using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.SportGroups
{
    public class SportGroupController : Controller
    {
        private readonly BarnamaConntext _context;

        public SportGroupController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: SportGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.SportGroups.ToListAsync());
        }

        // GET: SportGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportGroup = await _context.SportGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportGroup == null)
            {
                return NotFound();
            }

            return View(sportGroup);
        }

        // GET: SportGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl")] SportGroup sportGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportGroup);
        }

        // GET: SportGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportGroup = await _context.SportGroups.FindAsync(id);
            if (sportGroup == null)
            {
                return NotFound();
            }
            return View(sportGroup);
        }

        // POST: SportGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl")] SportGroup sportGroup)
        {
            if (id != sportGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportGroupExists(sportGroup.Id))
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
            return View(sportGroup);
        }

        // GET: SportGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportGroup = await _context.SportGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportGroup == null)
            {
                return NotFound();
            }

            return View(sportGroup);
        }

        // POST: SportGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportGroup = await _context.SportGroups.FindAsync(id);
            _context.SportGroups.Remove(sportGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportGroupExists(int id)
        {
            return _context.SportGroups.Any(e => e.Id == id);
        }
    }
}
