using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LeitnerApi.Controllers.Foods {
    public class FoodController : Controller {
        private readonly BarnamaConntext _context;
        private IWebHostEnvironment _env;
        public FoodController (BarnamaConntext context, IWebHostEnvironment env) {
            _context = context;
            _env = env;
        }

        // GET: Food
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.Foods.Include (f => f.Group);
            return View (await barnamaConntext.ToListAsync ());
        }
        public DataSourceResult GetFoods () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Foods.Include (x => x.FoodUnits).ThenInclude (x => x.Unit).Include (x => x.SicknessFoods).ThenInclude (x => x.Sickness);
            return list.AsQueryable ()
                .ToDataSourceResult (5, request.Skip, request.Sort, request.Filter);
        }

        public IActionResult ReadExcell (string fileName) {
            SpreadsheetInfo.SetLicense ("FREE-LIMITED-KEY");
            string path = Path.Combine (this._env.WebRootPath, "uploads\\") + fileName;
            var workbook = ExcelFile.Load (path);

            // Iterate through all worksheets in an Excel workbook.
            for (var i = 0; i < 1; i++) {

                int rowCount = 0;

                // Iterate through all rows in an Excel worksheet.
                foreach (var row in workbook.Worksheets[0].Rows) {

                    // Iterate through all allocated cells in an Excel row.
                    for (int j = 0; j < row.AllocatedCells.Count; j++)
                        if (row.AllocatedCells[j].ValueType != CellValueType.Null) {

                            if (j == 0 && rowCount != 0) {
                                Console.WriteLine (row.AllocatedCells[j].Value.ToString ());
                                addFood (row.AllocatedCells[j].Value.ToString ().Trim (), row.AllocatedCells[1].Value.ToString ().RemoveDigits ().Trim (), double.Parse (row.AllocatedCells[2].Value.ToString ()), double.Parse (row.AllocatedCells[3].Value.ToString ()), double.Parse (row.AllocatedCells[4].Value.ToString ()), double.Parse (row.AllocatedCells[5].Value.ToString ()), double.Parse (row.AllocatedCells[6].Value.ToString ()), double.Parse (row.AllocatedCells[7].Value.ToString ()), double.Parse (row.AllocatedCells[8].Value.ToString ()), double.Parse (row.AllocatedCells[9].Value.ToString ()), double.Parse (row.AllocatedCells[10].Value.ToString ()), double.Parse (row.AllocatedCells[11].Value.ToString ()), double.Parse (row.AllocatedCells[12].Value.ToString ()), double.Parse (row.AllocatedCells[13].Value.ToString ())

                                    , double.Parse (row.AllocatedCells[14].Value.ToString ()), double.Parse (row.AllocatedCells[15].Value.ToString ()), double.Parse (row.AllocatedCells[16].Value.ToString ())

                                );
                            }
                        }
                    else {
                        //    if(rowCount >1 && j == 0 ){
                        //        addFood (row.AllocatedCells[j].Value.ToString (),row.AllocatedCells[j].Value.ToString ());
                        //    }
                    }

                    rowCount++;
                }
            }

            return Ok ();
        }

        void addFood (string title, string unitTitle, double? calorie, double? Protein, double? Carbohydrate, double? Fat, double? Sugar, double? Sodium, double? Potassium, double? Magnesium, double? Calcium, double? Phosphor, double? Iron, double? Umfa, double? Upfa, double? Sfa, double? Tfa) {

            var food = _context.Foods.Where (x => x.Title == title).Include (x => x.FoodUnits).FirstOrDefault ();
            var unit = _context.Units.Where (x => x.Title.Trim() == unitTitle.Trim()).FirstOrDefault ();
            if (unit == null) {
                unit = new Unit ();
                unit.Title = unitTitle;
                _context.Units.Add (unit);

            }
            if (food == null) {
                food = new Food ();
                food.Title = title;
                food.GroupId = 1;
                _context.Foods.Add (food);
            } else {
                if (unit.Id > 0) {
                    var foodUnits = _context.FoodUnits.Where (x => x.FoodId == food.Id && x.UnitId == unit.Id);
                    _context.FoodUnits.RemoveRange (foodUnits);
                    _context.SaveChanges ();
                }
                //  food.FoodUnits.Clear();

            }
            FoodUnit foodUnit = new FoodUnit ();
            foodUnit.Food = food;
            foodUnit.Unit = unit;
            foodUnit.Calorie = calorie;
            foodUnit.Protein = Protein;
            foodUnit.Carbohydrate = Carbohydrate;
            foodUnit.Fat = Fat;
            foodUnit.Sugar = Sugar;
            foodUnit.Sodium = Sodium;
            foodUnit.Potassium = Potassium;
            foodUnit.Magnesium = Magnesium;
            foodUnit.Calcium = Calcium;
            foodUnit.Phosphor = Phosphor;
            foodUnit.Iron = Iron;
            foodUnit.Umfa = Umfa;
            foodUnit.Upfa = Upfa;
            foodUnit.Sfa = Sfa;
            foodUnit.Tfa = Tfa;
            if (unit.Title.Contains ("گرم")) {
                foodUnit.Calorie = calorie / 100;
                foodUnit.Protein = Protein / 100;
                foodUnit.Carbohydrate = Carbohydrate / 100;
                foodUnit.Fat = Fat / 100;
                foodUnit.Sugar = Sugar / 100;
                foodUnit.Sodium = Sodium / 100;
                foodUnit.Potassium = Potassium / 100;
                foodUnit.Magnesium = Magnesium / 100;
                foodUnit.Calcium = Calcium / 100;
                foodUnit.Phosphor = Phosphor / 100;
                foodUnit.Iron = Iron / 100;
                foodUnit.Umfa = Umfa / 100;
                foodUnit.Upfa = Upfa / 100;
                foodUnit.Sfa = Sfa / 100;
                foodUnit.Tfa = Tfa / 100;
            }
            _context.FoodUnits.Add (foodUnit);
            _context.SaveChanges ();

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
        public async Task<IActionResult> Create ([Bind ("Id,Title,GroupId")] Food food, List<int> MeelIds, List<int> NutrientIds,
            List<int> UnitIds, List<string> foodImages, List<int> SicknessIds) {
            if (ModelState.IsValid) {

                foreach (int id in MeelIds) {
                    FoodMeel foodMeel = new FoodMeel { MeelId = id, Food = food };
                    _context.FoodMeels.Attach (foodMeel); // without this, EF will try to create new 
                    food.FoodMeels.Add (foodMeel);

                }
                foreach (int id in NutrientIds) {
                    FoodNutrient foodNutrient = new FoodNutrient { NutrientId = id, Food = food };
                    _context.FoodNutrients.Attach (foodNutrient);
                }

                foreach (int id in UnitIds) {
                    FoodUnit foodUnit = new FoodUnit { UnitId = id, Food = food };
                    _context.FoodUnits.Attach (foodUnit);
                }

                foreach (int id in SicknessIds) {
                    SicknessFood sicknessFood = new SicknessFood { FoodId = id, Food = food };
                    _context.SicknessFoods.Attach (sicknessFood);
                }

                foreach (string image in foodImages) {

                    FoodImage foodImage = new FoodImage { ImageUrl = image, Food = food };
                    _context.FoodImages.Attach (foodImage);
                }
                _context.Add (food);
                await _context.SaveChangesAsync ();
                // return RedirectToAction (nameof (Index));
                return Json ("ok");
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

            var SelectedNutrientIds = _context.FoodNutrients.Where (x => x.FoodId == food.Id).Select (x => x.NutrientId).ToArray ();
            ViewData["SelectedNutrientIds"] = SelectedNutrientIds;
            var SelectedUnitIds = _context.FoodUnits.Where (x => x.FoodId == food.Id).Select (x => x.UnitId).ToArray ();
            ViewData["SelectedUnitIds"] = SelectedUnitIds;

            var SelectedImages = _context.FoodImages.Where (x => x.FoodId == id).Select (x => x.ImageUrl).ToList ();
            ViewData["SelectedImages"] = SelectedImages;

            var SelectedSicks = _context.SicknessFoods.Where (x => x.FoodId == id).Select (x => x.SicknessId).ToList ();
            ViewData["SelectedSicks"] = SelectedSicks;

            return View (food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, string title, int groupId, List<int> MeelIds, List<int> NutrientIds, List<int> UnitIds, List<string> foodImages, List<int> SicknessIds) {

            if (ModelState.IsValid) {
                try {

                    var model = _context.Foods
                        .Include (x => x.FoodMeels).Include (x => x.FoodNutrients).Include (x => x.FoodUnits).Include (x => x.FoodImages).Include (x => x.SicknessFoods)
                        .FirstOrDefault (x => x.Id == id);
                    model.GroupId = groupId;
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

                    model.SicknessFoods.Clear ();
                    foreach (int sickId in SicknessIds) {
                        SicknessFood sicknessFood = new SicknessFood { SicknessId = sickId, Food = model };
                        model.SicknessFoods.Add (sicknessFood);
                    }

                    //model.FoodUnits.Clear ();
                    foreach (int unitId in UnitIds) {
                        if (!_context.FoodUnits.Any (x => x.UnitId == unitId && x.FoodId == model.Id)) {
                           FoodUnit foodUnit = new FoodUnit { UnitId = unitId, Food = model };
                           model.FoodUnits.Add (foodUnit);
                        }

                        //FoodUnit foodUnit = new FoodUnit { UnitId = unitId, Food = model };
                        // model.FoodUnits.Add (foodUnit);
                    }
                    model.FoodImages.Clear ();
                    foreach (string image in foodImages) {

                        FoodImage foodImage = new FoodImage { ImageUrl = image, Food = model };
                        model.FoodImages.Add (foodImage);
                    }
                    _context.SaveChanges ();

                    // return RedirectToAction ("Index");
                    return Json ("ok");

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
            return Json ("ok");
        }

        private bool FoodExists (int id) {
            return _context.Foods.Any (e => e.Id == id);
        }
    }
}