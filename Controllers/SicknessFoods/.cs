using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeitnerApi.Controllers.SicknessFoods
{
    public class SicknessFoodController : Controller
    {
        private readonly BarnamaConntext _context;

        public SicknessFoodController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: SicknessFood
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.SicknessFoods.Include(s => s.Food).Include(s => s.Sickness);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: SicknessFood/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sicknessFood = await _context.SicknessFoods
                .Include(s => s.Food)
                .Include(s => s.Sickness)
                .FirstOrDefaultAsync(m => m.SicknessId == id);
            if (sicknessFood == null)
            {
                return NotFound();
            }

            return View(sicknessFood);
        }

        // GET: SicknessFood/Create
        public IActionResult Create()
        {
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id");
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id");
            return View();
        }

        // POST: SicknessFood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,SicknessId,MustBe")] SicknessFood sicknessFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sicknessFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id", sicknessFood.FoodId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", sicknessFood.SicknessId);
            return View(sicknessFood);
        }

        // GET: SicknessFood/Edit/5
        public async Task<IActionResult> Edit(int? foodId,int? sickId)
        {
              if (foodId == null  || sickId ==null)
            {
                return NotFound();
            }

            var sickFood = await _context.SicknessFoods.Where(x=>x.FoodId==foodId && x.SicknessId ==sickId).FirstAsync();
            if (sickFood == null)
            {
                return NotFound();
            }
        
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id", sickFood.FoodId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", sickFood.SicknessId);
            return View(sickFood);
        }

        // POST: SicknessFood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("FoodId,SicknessId,MustBe")] SicknessFood sicknessFood)
        {
       

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sicknessFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SicknessFoodExists(sicknessFood.SicknessId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json("ok");
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "Id", "Id", sicknessFood.FoodId);
            ViewData["SicknessId"] = new SelectList(_context.Sicknesses, "Id", "Id", sicknessFood.SicknessId);
            return Json("ok");
        }

        // GET: SicknessFood/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sicknessFood = await _context.SicknessFoods
                .Include(s => s.Food)
                .Include(s => s.Sickness)
                .FirstOrDefaultAsync(m => m.SicknessId == id);
            if (sicknessFood == null)
            {
                return NotFound();
            }

            return View(sicknessFood);
        }

        // POST: SicknessFood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? foodId,int? sickId)
        {
            var sicknessFood =  await _context.SicknessFoods.Where(x=>x.FoodId==foodId && x.SicknessId ==sickId).FirstAsync();
            _context.SicknessFoods.Remove(sicknessFood);
            await _context.SaveChangesAsync();
            return Json("ok");
        }

        private bool SicknessFoodExists(int id)
        {
            return _context.SicknessFoods.Any(e => e.SicknessId == id);
        }
    }
}
