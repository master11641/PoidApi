using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class InvoiceCountComponent : ViewComponent
    {
       private readonly BarnamaConntext _context;

        public InvoiceCountComponent(BarnamaConntext context)
        {
          _context = context;
        }

        public IViewComponentResult Invoke(int numberToTake)
        {
            var amount =  _context.Invoices.Where(x=>x.RefId!=null).Sum(x=>x.Amount);
            return View(viewName: "Default", model: amount);
        }

        //public async Task<IViewComponentResult> InvokeAsync(int numberToTake)
        //{
        //    return View();
        //}
    }