using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.FoodUnits
{
    public class FoodUnitController : Controller
    {
        private readonly BarnamaConntext _context;

        public FoodUnitController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: FoodUnit
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.FoodUnits.Include(f => f.Food).Include(f => f.Unit);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: FoodUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodUnit = await _context.FoodUnits
                .Include(f => f.Food)
                .Include(f => f.Unit)
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (foodUnit == null)
            {
                return NotFound();
            }

            return View(foodUnit);
        }

        // GET: FoodUnit/Create
        public IActionResult Create()
        {
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id");
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "Id");
            return View();
        }

        // POST: FoodUnit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,UnitId,Calorie")] FoodUnit foodUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id", foodUnit.FoodId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "Id", foodUnit.UnitId);
            return View(foodUnit);
        }

        // GET: FoodUnit/Edit/5
        public async Task<IActionResult> Edit(int? foodId,int? unitId)
        {
            if (foodId == null  || unitId ==null)
            {
                return NotFound();
            }

            var foodUnit = await _context.FoodUnits.Where(x=>x.FoodId==foodId && x.UnitId ==unitId).FirstAsync();
            if (foodUnit == null)
            {
                return NotFound();
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Title", foodUnit.FoodId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Id", "Title", foodUnit.UnitId);
            return View(foodUnit);
        }

        // POST: FoodUnit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FoodId,UnitId,Calorie")] FoodUnit foodUnit)
        {
       

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodUnitExists(foodUnit.FoodId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Json("ok");
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Title", foodUnit.FoodId);
            ViewData["UnitId"] = new SelectList(_context.Set<Unit>(), "Title", "Id", foodUnit.UnitId);
            return View(foodUnit);
        }

        // GET: FoodUnit/Delete/5
        public async Task<IActionResult> Delete(int? foodId,int? unitId)
        {
        

            var foodUnit = await _context.FoodUnits
                .Include(f => f.Food)
                .Include(f => f.Unit)
                .FirstOrDefaultAsync(m => m.FoodId == foodId && m.UnitId == unitId);
            if (foodUnit == null)
            {
                return NotFound();
            }

            return View(foodUnit);
        }

        // POST: FoodUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? foodId,int? unitId)
        {
           var foodUnit = await _context.FoodUnits
                .Include(f => f.Food)
                .Include(f => f.Unit)
                .FirstOrDefaultAsync(m => m.FoodId == foodId && m.UnitId == unitId);
            _context.FoodUnits.Remove(foodUnit);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
             return Json("ok");
        }

        private bool FoodUnitExists(int id)
        {
            return _context.FoodUnits.Any(e => e.FoodId == id);
        }
    }
}
