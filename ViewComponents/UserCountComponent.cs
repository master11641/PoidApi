using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class UserCountComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public UserCountComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var model =  _context.Users.Count();
            return View(viewName: "Default", model: model);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        //{
        //    return View();
        //}
    }