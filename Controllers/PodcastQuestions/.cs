using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.PodcastQuestions
{
    public class PodcastQuestionController : Controller
    {
        private readonly BarnamaConntext _context;

        public PodcastQuestionController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: PodcastQuestion
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.PodcastQuestions.Include(p => p.Podcast).Include(p => p.Question);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: PodcastQuestion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastQuestion = await _context.PodcastQuestions
                .Include(p => p.Podcast)
                .Include(p => p.Question)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcastQuestion == null)
            {
                return NotFound();
            }

            return View(podcastQuestion);
        }

        // GET: PodcastQuestion/Create
        public IActionResult Create()
        {
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: PodcastQuestion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PodcastId,QuestionId")] PodcastQuestion podcastQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcastQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastQuestion.PodcastId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", podcastQuestion.QuestionId);
            return View(podcastQuestion);
        }

        // GET: PodcastQuestion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastQuestion = await _context.PodcastQuestions.FindAsync(id);
            if (podcastQuestion == null)
            {
                return NotFound();
            }
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastQuestion.PodcastId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", podcastQuestion.QuestionId);
            return View(podcastQuestion);
        }

        // POST: PodcastQuestion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PodcastId,QuestionId")] PodcastQuestion podcastQuestion)
        {
            if (id != podcastQuestion.PodcastId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcastQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastQuestionExists(podcastQuestion.PodcastId))
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
            ViewData["PodcastId"] = new SelectList(_context.Podcasts, "Id", "Id", podcastQuestion.PodcastId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", podcastQuestion.QuestionId);
            return View(podcastQuestion);
        }

        // GET: PodcastQuestion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var podcastQuestion = await _context.PodcastQuestions
                .Include(p => p.Podcast)
                .Include(p => p.Question)
                .FirstOrDefaultAsync(m => m.PodcastId == id);
            if (podcastQuestion == null)
            {
                return NotFound();
            }

            return View(podcastQuestion);
        }

        // POST: PodcastQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var podcastQuestion = await _context.PodcastQuestions.FindAsync(id);
            _context.PodcastQuestions.Remove(podcastQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastQuestionExists(int id)
        {
            return _context.PodcastQuestions.Any(e => e.PodcastId == id);
        }
    }
}
