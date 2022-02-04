using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LeitnerApi.Controllers.Foods {
    public class FoodController : Controller {
        private readonly BarnamaConntext _context;

        public FoodController (BarnamaConntext context) {
            _context = context;
        }

        // GET: Food
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.Foods.Include (f => f.Group);
            return View (await barnamaConntext.ToListAsync ());
        }
       public DataSourceResult GetFoods () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Foods.Include(x=>x.Group).Include(x=>x.FoodMeels).Include(x=>x.FoodNutrients).Include(x=>x.FoodUnits).ThenInclude(x=>x.Unit);
            return list.AsQueryable ()
                .ToDataSourceResult (request.Take, request.Skip, request.Sort, request.Filter);
        }
        // GET: Food/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var food = await _context.Foods
                .Include (f => f.Group)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (food == null) {
                return NotFound ();
            }

            return View (food);
        }

        // GET: Food/Create
        public IActionResult Create () {
            // var selectedItems = _context.Meel.Select (x => new { x.Id }).ToList ();          
            // ViewData["Meels"] = new SelectList (_context.Meel, "Id", "Title");
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "Title");
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Title,GroupId")] Food food, List<int> MeelIds, List<int> NutrientIds, List<int> UnitIds, List<string> foodImages) {
            if (ModelState.IsValid) {

                foreach (int id in MeelIds) {
                    FoodMeel foodMeel = new FoodMeel { MeelId = id, Food = food };
                    _context.FoodMeels.Attach (foodMeel); // without this, EF will try to create new 
                    food.FoodMeels.Add (foodMeel);

                }
                foreach (int id in NutrientIds) {
                    FoodNutrient foodNutrient = new FoodNutrient { NutrientId = id, Food = food };
                    _context.foodNutrients.Attach (foodNutrient);
                }

                foreach (int id in UnitIds) {
                    FoodUnit foodUnit = new FoodUnit { UnitId = id, Food = food };
                    _context.FoodUnits.Attach (foodUnit);
                }
                foreach (string image in foodImages) {

                    FoodImage foodImage = new FoodImage { ImageUrl = image, Food = food };
                    _context.FoodImages.Attach (foodImage);
                }
                _context.Add (food);
                await _context.SaveChangesAsync ();
               // return RedirectToAction (nameof (Index));
               return Json("ok");
            }
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "Id", food.GroupId);
            return View (food);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var food = await _context.Foods.FindAsync (id);
            if (food == null) {
                return NotFound ();
            }
            ViewData["GroupId"] = new SelectList (_context.Groups, "Id", "Title", food.GroupId);
            var SelectedMeelIds = _context.FoodMeels.Where (x => x.FoodId == food.Id).Select (x => x.MeelId).ToArray ();
            ViewData["SelectedMeelIds"] = SelectedMeelIds;

            var SelectedNutrientIds = _context.foodNutrients.Where (x => x.FoodId == food.Id).Select (x => x.NutrientId).ToArray ();
            ViewData["SelectedNutrientIds"] = SelectedNutrientIds;
            var SelectedUnitIds = _context.FoodUnits.Where (x => x.FoodId == food.Id ).Select (x => x.UnitId).ToArray ();
            ViewData["SelectedUnitIds"] = SelectedUnitIds;

            var SelectedImages = _context.FoodImages.Where (x => x.FoodId == id).Select (x => x.ImageUrl).ToList ();
            ViewData["SelectedImages"] = SelectedImages;

            return View (food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, string title, int groupId, List<int> MeelIds, List<int> NutrientIds, List<int> UnitIds, List<string> foodImages) {

            if (ModelState.IsValid) {
                try {

                    var model = _context.Foods
                        .Include (x => x.FoodMeels).Include (x => x.FoodNutrients).Include (x => x.FoodUnits).Include(x=>x.FoodImages)
                        .FirstOrDefault (x => x.Id == id);

                    model.FoodMeels.Clear ();
                    foreach (int meelId in MeelIds) {
                        FoodMeel foodMeel = new FoodMeel { MeelId = meelId, Food = model };
                        model.FoodMeels.Add (foodMeel);

                    }

                    model.FoodNutrients.Clear ();
                    foreach (int nutId in NutrientIds) {
                        FoodNutrient foodNutrient = new FoodNutrient { NutrientId = nutId, Food = model };
                        model.FoodNutrients.Add (foodNutrient);
                    }

                    model.FoodUnits.Clear ();
                    foreach (int unitId in UnitIds) {
                        FoodUnit foodUnit = new FoodUnit { UnitId = unitId, Food = model };
                        model.FoodUnits.Add (foodUnit);
                    }
                    model.FoodImages.Clear();
                    foreach (string image in foodImages) {

                        FoodImage foodImage = new FoodImage { ImageUrl = image, Food = model };
                        model.FoodImages.Add (foodImage);
                    }
                    _context.SaveChanges ();

                   // return RedirectToAction ("Index");
                     return Json("ok");

                } catch (DbUpdateConcurrencyException) {
                    if (!FoodExists (id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }

            }
            // ViewData["GroupId"] = new SelectList (_context.Group, "Id", "Id", food.GroupId);
            return View ();
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var food = await _context.Foods
                .Include (f => f.Group)
                .FirstOrDefaultAsync (m => m.Id == id);
            if (food == null) {
                return NotFound ();
            }

            return View (food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var food = await _context.Foods.FindAsync (id);
            _context.Foods.Remove (food);
            await _context.SaveChangesAsync ();
            return Json("ok");
        }

        private bool FoodExists (int id) {
            return _context.Foods.Any (e => e.Id == id);
        }
    }
}