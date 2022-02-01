using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class LastServicesComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public LastServicesComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var model =  _context.ServicePackages.OrderByDescending(x=>x.Id).Take(12).ToList();
            return View(viewName: "Default", model: model);
        }
     
    }