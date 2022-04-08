using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.SImages
{
    public class SImageController : Controller
    {
        private readonly BarnamaConntext _context;

        public SImageController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: SImage
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.SImages.Include(s => s.SportItem);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: SImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sImage = await _context.SImages
                .Include(s => s.SportItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sImage == null)
            {
                return NotFound();
            }

            return View(sImage);
        }

        // GET: SImage/Create
        public IActionResult Create()
        {
            ViewData["SportItemId"] = new SelectList(_context.SportItems, "Id", "Id");
            return View();
        }

        // POST: SImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,SportItemId")] SImage sImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportItemId"] = new SelectList(_context.SportItems, "Id", "Id", sImage.SportItemId);
            return View(sImage);
        }

        // GET: SImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sImage = await _context.SImages.FindAsync(id);
            if (sImage == null)
            {
                return NotFound();
            }
            ViewData["SportItemId"] = new SelectList(_context.SportItems, "Id", "Id", sImage.SportItemId);
            return View(sImage);
        }

        // POST: SImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,SportItemId")] SImage sImage)
        {
            if (id != sImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SImageExists(sImage.Id))
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
            ViewData["SportItemId"] = new SelectList(_context.SportItems, "Id", "Id", sImage.SportItemId);
            return View(sImage);
        }

        // GET: SImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sImage = await _context.SImages
                .Include(s => s.SportItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sImage == null)
            {
                return NotFound();
            }

            return View(sImage);
        }

        // POST: SImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sImage = await _context.SImages.FindAsync(id);
            _context.SImages.Remove(sImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SImageExists(int id)
        {
            return _context.SImages.Any(e => e.Id == id);
        }
    }
}
