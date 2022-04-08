using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.PodcastSicknesses
{
    public class PodcastSicknessController : Controller
    {
        private readonly BarnamaConntext _context;

        public PodcastSicknessController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: PodcastSickness
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.PodcastSicknesses.Include(p => p.Podcast).Include(p => p.Sickness);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: PodcastSickness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastSickness = await _context.PodcastSicknesses
                .Include(p => p.Podcast)
                .Include(p => p.Sickness)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcastSickness == null)
            {
                return NotFound();
            }

            return View(podcastSickness);
        }

        // GET: PodcastSickness/Create
        public IActionResult Create()
        {
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id");
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id");
            return View();
        }

        // POST: PodcastSickness/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PodcastId,SicknessId")] PodcastSickness podcastSickness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastSickness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastSickness.PodcastId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", podcastSickness.SicknessId);
            return View(podcastSickness);
        }

        // GET: PodcastSickness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastSickness = await _context.PodcastSicknesses.FindAsync(id);
            if (podcastSickness == null)
            {
                return NotFound();
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastSickness.PodcastId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", podcastSickness.SicknessId);
            return View(podcastSickness);
        }

        // POST: PodcastSickness/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PodcastId,SicknessId")] PodcastSickness podcastSickness)
        {
            if (id != podcastSickness.PodcastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastSickness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastSicknessExists(podcastSickness.PodcastId))
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
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastSickness.PodcastId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", podcastSickness.SicknessId);
            return View(podcastSickness);
        }

        // GET: PodcastSickness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastSickness = await _context.PodcastSicknesses
                .Include(p => p.Podcast)
                .Include(p => p.Sickness)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcastSickness == null)
            {
                return NotFound();
            }

            return View(podcastSickness);
        }

        // POST: PodcastSickness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podcastSickness = await _context.PodcastSicknesses.FindAsync(id);
            _context.PodcastSicknesses.Remove(podcastSickness);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastSicknessExists(int id)
        {
            return _context.PodcastSicknesses.Any(e => e.PodcastId == id);
        }
    }
}
