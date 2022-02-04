using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class FoodCountComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public FoodCountComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var model =  _context.Foods.Count();
            return View(viewName: "Default", model: model);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        //{
        //    return View();
        //}
    }