using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.SportItems {
    public class SportItemController : Controller {
        private readonly BarnamaConntext _context;

        public SportItemController (BarnamaConntext context) {
            _context = context;
        }

        // GET: SportItem
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.SportItems.Include (s => s.Sport);
            return View (await barnamaConntext.ToListAsync ());
        }

        // GET: SportItem/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sportItem = await _context.SportItems
                .Include (s => s.Sport)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (sportItem == null) {
                return NotFound ();
            }

            return View (sportItem);
        }

        // GET: SportItem/Create
        public IActionResult Create () {
            ViewData["SportId"] = new SelectList (_context.Sports, "Id", "Title");
            return View ();
        }

        // POST: SportItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,Description,DescriptionAudio,DescriptionVideo,SportId")] SportItem sportItem, List<string> images) {
            if (ModelState.IsValid) {
                foreach (var imageUrl in images)
                {
                    sportItem.SImages.Add(
                    new SImage{
                        ImageUrl =  imageUrl,
                        
                    }
                );
                }
                
                _context.Add (sportItem);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["SportId"] = new SelectList (_context.Sports, "Id", "Title", sportItem.SportId);
            return View (sportItem);
        }

        // GET: SportItem/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sportItem = await _context.SportItems.Include (x => x.SImages).FirstOrDefaultAsync (x => x.Id == id);
            if (sportItem == null) {
                return NotFound ();
            }
            ViewData["SportId"] = new SelectList (_context.Sports, "Id", "Title", sportItem.SportId);
            var SelectedImages = _context.SImages.Where(x=>x.SportItemId==id).Select (x => x.ImageUrl).ToList ();
            ViewData["SelectedImages"] = SelectedImages;
            return View (sportItem);
        }

        // POST: SportItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, string Title, string Description, string DescriptionAudio, string DescriptionVideo, int SportId, List<string> images) {

            if (ModelState.IsValid) {
                try {
                    var model = _context.SportItems
                        .Include (x => x.SImages)
                        .FirstOrDefault (x => x.Id == id);
                    model.Title = Title;
                    model.Description = Description;
                    model.DescriptionAudio = DescriptionAudio;
                    model.DescriptionVideo = DescriptionVideo;
                    model.SportId = SportId;
                    model.SImages.Clear ();                    
                    foreach (string image in images) {

                        SImage foodImage = new SImage { ImageUrl = image, SportItem = model };
                        model.SImages.Add (foodImage);
                    }

                    _context.SaveChanges ();

                } catch (DbUpdateConcurrencyException) {
                    // if (!SportItemExists(model.Id))
                    // {
                    //     return NotFound();
                    // }
                    // else
                    // {
                    //     throw;
                    // }
                }
                return RedirectToAction (nameof (Index));
            }
            // ViewData["SportId"] = new SelectList(_context.Sports, "Id", "Title", sportItem.SportId);
            return View ();
        }

        // GET: SportItem/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sportItem = await _context.SportItems
                .Include (s => s.Sport)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (sportItem == null) {
                return NotFound ();
            }

            return View (sportItem);
        }

        // POST: SportItem/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var sportItem = await _context.SportItems.FindAsync (id);
            _context.SportItems.Remove (sportItem);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool SportItemExists (int id) {
            return _context.SportItems.Any (e => e.Id == id);
        }
    }
}