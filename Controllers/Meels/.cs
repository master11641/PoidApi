using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.Meels
{
    public class MeelController : Controller
    {
        private readonly BarnamaConntext _context;

        public MeelController(BarnamaConntext context)
        {
            _context = context;
        }
     [HttpGet]
        public List<Meel> GetMeels () {
            return _context.Meels.ToList ();
        }
        // GET: Meel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meels.ToListAsync());
        }

        // GET: Meel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meel = await _context.Meels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meel == null)
            {
                return NotFound();
            }

            return View(meel);
        }

        // GET: Meel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageUrl")] Meel meel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meel);
        }

        // GET: Meel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meel = await _context.Meels.FindAsync(id);
            if (meel == null)
            {
                return NotFound();
            }
            return View(meel);
        }

        // POST: Meel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageUrl")] Meel meel)
        {
            if (id != meel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeelExists(meel.Id))
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
            return View(meel);
        }

        // GET: Meel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meel = await _context.Meels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meel == null)
            {
                return NotFound();
            }

            return View(meel);
        }

        // POST: Meel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meel = await _context.Meels.FindAsync(id);
            _context.Meels.Remove(meel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeelExists(int id)
        {
            return _context.Meels.Any(e => e.Id == id);
        }
    }
}
