using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.PodcastGroups
{
    public class PodcastGroupController : Controller
    {
        private readonly BarnamaConntext _context;

        public PodcastGroupController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: PodcastGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.PodcastGroups.ToListAsync());
        }

        // GET: PodcastGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastGroup = await _context.PodcastGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastGroup == null)
            {
                return NotFound();
            }

            return View(podcastGroup);
        }

        // GET: PodcastGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PodcastGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] PodcastGroup podcastGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcastGroup);
        }

        // GET: PodcastGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastGroup = await _context.PodcastGroups.FindAsync(id);
            if (podcastGroup == null)
            {
                return NotFound();
            }
            return View(podcastGroup);
        }

        // POST: PodcastGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] PodcastGroup podcastGroup)
        {
            if (id != podcastGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastGroupExists(podcastGroup.Id))
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
            return View(podcastGroup);
        }

        // GET: PodcastGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastGroup = await _context.PodcastGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcastGroup == null)
            {
                return NotFound();
            }

            return View(podcastGroup);
        }

        // POST: PodcastGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podcastGroup = await _context.PodcastGroups.FindAsync(id);
            _context.PodcastGroups.Remove(podcastGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastGroupExists(int id)
        {
            return _context.PodcastGroups.Any(e => e.Id == id);
        }
    }
}
