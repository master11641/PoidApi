using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LastInvoicesComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public LastInvoicesComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var model =  _context.Invoices.Include(x=>x.ServicePackage).Where(x=>x.ServicePackage.Price != 0).OrderByDescending(x=>x.Id).Take(12).ToList();
            return View(viewName: "Default", model: model);
        }
     
    }