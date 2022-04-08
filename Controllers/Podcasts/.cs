using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LeitnerApi.Controllers.Podcasts {
    public class PodcastController : Controller {
        private readonly BarnamaConntext _context;

        public PodcastController (BarnamaConntext context) {
            _context = context;
        }

        // GET: Podcast
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.Podcasts.Include (p => p.PodcastGroup);
            return View (await barnamaConntext.ToListAsync ());
        }
        public DataSourceResult GetPodcasts () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Podcasts.Include (x => x.PodcastGroup);
            return list.AsQueryable ()
                .ToDataSourceResult (5, request.Skip, request.Sort, request.Filter);
        }
        // GET: Podcast/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var podcast = await _context.Podcasts
                .Include (p => p.PodcastGroup)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (podcast == null) {
                return NotFound ();
            }

            return View (podcast);
        }

        // GET: Podcast/Create
        public IActionResult Create () {
            ViewData["PodcastGroupId"] = new SelectList (_context.PodcastGroups, "Id", "Id");

            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,PodcastGroupId,PodcastAudio")] Podcast podcast) {
            if (ModelState.IsValid) {
                _context.Add (podcast);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["PodcastGroupId"] = new SelectList (_context.PodcastGroups, "Id", "Id", podcast.PodcastGroupId);
            return View (podcast);
        }

        // GET: Podcast/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var podcast = await _context.Podcasts.FindAsync (id);
            if (podcast == null) {
                return NotFound ();
            }
            ViewData["PodcastGroupId"] = new SelectList (_context.PodcastGroups, "Id", "Id", podcast.PodcastGroupId);
            var QuestionIds = _context.PodcastQuestions.Where (x => x.PodcastId == podcast.Id).Select (x => x.QuestionId).ToArray ();
            ViewData["QuestionIds"] = QuestionIds;

            var SicknessIds = _context.PodcastSicknesses.Where (x => x.PodcastId == podcast.Id).Select (x => x.SicknessId).ToArray ();
            ViewData["SicknessIds"] = SicknessIds;

            return View (podcast);
        }

        // POST: Podcast/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, string title, int PodcastGroupId, string PodcastAudio, List<int> QuestionIds, List<int> SicknessIds) {
            if (ModelState.IsValid) {
                try {
                    var model = _context.Podcasts
                        .Include (x => x.PodcastQuestions)
                        .Include (x => x.PodcastSicknesses)
                        .FirstOrDefault (x => x.Id == id);
                    model.PodcastAudio = PodcastAudio;
                    model.Title = title;

                    model.PodcastGroupId = PodcastGroupId;
                    model.PodcastQuestions.Clear ();
                    foreach (int questionId in QuestionIds) {
                        PodcastQuestion foodMeel = new PodcastQuestion { QuestionId = questionId, Podcast = model };
                        model.PodcastQuestions.Add (foodMeel);

                    }

                    model.PodcastSicknesses.Clear ();
                    foreach (int sicknessId in SicknessIds) {
                        PodcastSickness temp = new PodcastSickness { SicknessId = sicknessId, Podcast = model };
                        model.PodcastSicknesses.Add (temp);

                    }
                    _context.SaveChanges ();
                    return Json ("ok");
                } catch (DbUpdateConcurrencyException) {
                    return NotFound ();
                }
            }
            return View ();
        }

        // GET: Podcast/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var podcast = await _context.Podcasts
                .Include (p => p.PodcastGroup)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (podcast == null) {
                return NotFound ();
            }

            return View (podcast);
        }

        // POST: Podcast/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var podcast = await _context.Podcasts.FindAsync (id);
            _context.Podcasts.Remove (podcast);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool PodcastExists (int id) {
            return _context.Podcasts.Any (e => e.Id == id);
        }
    }
}