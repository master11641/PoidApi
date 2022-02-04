using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Barnama.Controllers.Invoices
{
     [Authorize(UserInRole ="admin")]
    public class InvoiceController : Controller
    {
        private readonly BarnamaConntext _context;

        public InvoiceController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.Invoices.Include(i => i.ServicePackage).Include(i => i.User);
            return View(await barnamaConntext.ToListAsync());
        }
      public DataSourceResult GetInvoices () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Invoices.Include(x=>x.ServicePackage);
            return list.AsQueryable ()
                .ToDataSourceResult (request.Take, request.Skip, request.Sort, request.Filter);
        }
        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.ServicePackage)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            ViewData["ServicePackageId"] = new SelectList(_context.ServicePackages, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServicePackageId,RefId,RegisterDate,PaymentDate,Amount,Authority,UserId,IsConfirm")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
                return Json("ok"); 
            }
            ViewData["ServicePackageId"] = new SelectList(_context.ServicePackages, "Id", "Id", invoice.ServicePackageId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", invoice.UserId);
           // return View(invoice);
           return Json("ok"); 
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["ServicePackageId"] = new SelectList(_context.ServicePackages, "Id", "Id", invoice.ServicePackageId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", invoice.UserId);
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServicePackageId,RefId,RegisterDate,PaymentDate,Amount,Authority,UserId,IsConfirm")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["ServicePackageId"] = new SelectList(_context.ServicePackages, "Id", "Id", invoice.ServicePackageId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", invoice.UserId);
            //return View(invoice);
                 return Json("ok"); 
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.ServicePackage)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
