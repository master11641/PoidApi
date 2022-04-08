using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LeitnerApi.Controllers.Sports {
    public class SportController : Controller {
        private readonly BarnamaConntext _context;

        public SportController (BarnamaConntext context) {
            _context = context;
        }

        // GET: Sport
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.Sports.Include (s => s.SportGroup);
            return View (await barnamaConntext.ToListAsync ());
        }
        public DataSourceResult GetSports () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Sports.Include (x => x.SportGroup);
            return list.AsQueryable ()
                .ToDataSourceResult (5, request.Skip, request.Sort, request.Filter);
        }
        // GET: Sport/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sport = await _context.Sports
                .Include (s => s.SportGroup)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (sport == null) {
                return NotFound ();
            }

            return View (sport);
        }

        // GET: Sport/Create
        public IActionResult Create () {
            ViewData["SportGroupId"] = new SelectList (_context.SportGroups, "Id", "Title");
            return View ();
        }

        // POST: Sport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,ImageUrl,SportGroupId")] Sport sport) {
            if (ModelState.IsValid) {
                _context.Add (sport);
                await _context.SaveChangesAsync ();
                return Json("ok");
            }
            ViewData["SportGroupId"] = new SelectList (_context.SportGroups, "Id", "Title", sport.SportGroupId);
            return View (sport);
        }

        // GET: Sport/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sport = await _context.Sports.FindAsync (id);
            if (sport == null) {
                return NotFound ();
            }
            ViewData["SportGroupId"] = new SelectList (_context.SportGroups, "Id", "Title", sport.SportGroupId);
                 var MuscleIds = _context.SportMuscles.Where (x => x.SportId == sport.Id).Select (x => x.MuscleId).ToArray ();
            ViewData["MuscleIds"] = MuscleIds;
            return View (sport);
        }

        // POST: Sport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, string Title,string ImageUrl,int SportGroupId,
         List<int> MusclesIds) {
          

            if (ModelState.IsValid) {
                try {
                     var model = _context.Sports
                        .Include (x => x.SportMuscles)                      
                        .FirstOrDefault (x => x.Id == id);
                        model.Title = Title;
                        model.ImageUrl = ImageUrl;
                        model.SportGroupId = SportGroupId;
                         model.SportMuscles.Clear ();
                    foreach (int muscleId in MusclesIds) {
                        SportMuscle temp = new SportMuscle { MuscleId = muscleId, Sport = model };
                        model.SportMuscles.Add (temp);

                    }
                    _context.SaveChanges();

                } catch (DbUpdateConcurrencyException) {
                   
                }
               return Json("ok");
            }
            // ViewData["SportGroupId"] = new SelectList (_context.SportGroups, "Id", "Title", sport.SportGroupId);
            return View ();
        }

        // GET: Sport/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var sport = await _context.Sports
                .Include (s => s.SportGroup)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (sport == null) {
                return NotFound ();
            }

            return View (sport);
        }

        // POST: Sport/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var sport = await _context.Sports.FindAsync (id);
            _context.Sports.Remove (sport);
            await _context.SaveChangesAsync ();
             return Json("ok");
        }

        private bool SportExists (int id) {
            return _context.Sports.Any (e => e.Id == id);
        }
    }
}