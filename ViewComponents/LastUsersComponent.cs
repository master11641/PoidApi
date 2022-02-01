using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class LastUsersComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public LastUsersComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var model =  _context.Users.OrderByDescending(x=>x.Id).Take(12).ToList();
            return View(viewName: "Default", model: model);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        //{
        //    return View();
        //}
    }