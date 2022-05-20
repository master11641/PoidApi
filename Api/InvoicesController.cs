using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class InvoicesController : Controller {
        private BarnamaConntext _context;
        public InvoicesController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpPost ("AddInvoice")]
        public IActionResult AddInvoice (int servicePackageId, int amount, string authority, int userId) {
            Invoice invoice = new Invoice {
                RegisterDate = DateTime.Now,
                ServicePackageId = servicePackageId,
                Amount = amount,
                Authority = authority,
                UserId = userId
            };
            _context.Add (invoice);
            _context.SaveChanges ();
            return Ok (invoice.Id);

        }

        [HttpPost ("ConfirmInvoice")]
        public IActionResult ConfirmInvoice (int invoiceId, string refId, DateTime paymentDate) {
            Invoice invoice = _context.Invoices.Include(x=>x.ServicePackage).FirstOrDefault (x=>x.Id == invoiceId);
            if (invoice == null) {
                return NotFound ();
            }
            var currentDiet = _context.Diets.Include(x=>x.Plan)
               .Where (x => x.UserId == invoice.UserId).OrderByDescending (x => x.Id).FirstOrDefault ();
               currentDiet.Plan.EndDate = currentDiet.Plan.EndDate.AddDays(invoice.ServicePackage.ExpireAfterBuyInDays);
            invoice.RefId = refId;
            invoice.PaymentDate = paymentDate;
            invoice.IsConfirm = true;
            _context.SaveChanges ();
            return Ok (invoice.Id);
        }

  [HttpGet ("GetInvoiceUser")]
        public IActionResult GetInvoiceUser (int userId) {
            var response = _context.Invoices.Where (x => x.UserId == userId ).Include (x => x.ServicePackage).Select (x => new {
                x.Id,
                    x.Amount,
                    x.RegisterDate,
                    x.IsConfirm,
                    x.ServicePackage.Title,
                    package = x.ServicePackage
            }).ToList ().OrderByDescending (x => x.RegisterDate);
            if (response.Count () == 0) {
                int ServicePackageId = _context.ServicePackages.Where (x => x.IsTimed == false && x.ExpireAfterBuyInDays==30).FirstOrDefault ().Id;
                Invoice invoice = new Invoice {
                    RegisterDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    ServicePackageId = ServicePackageId,
                    Amount = 0,
                    Authority = "Authority",
                    UserId = userId,
                    IsConfirm = true,
                    RefId = "Gift"
                };
                _context.Add (invoice);
                _context.SaveChanges ();
                 response = _context.Invoices.Where (x => x.UserId == userId  ).Include (x => x.ServicePackage).Select (x => new {
                    x.Id,
                        x.Amount,
                        x.RegisterDate,
                        x.IsConfirm,
                        x.ServicePackage.Title,
                        package = x.ServicePackage,

                }).ToList ().OrderByDescending (x => x.RegisterDate);

            }
            return Ok (response);
        }
   
        [HttpPost ("VerifyPayment")]
        public IActionResult VerifyPayment (int invoiceId) {
            Invoice invoice = _context.Invoices.Find (invoiceId);
            string merchant = "883ee0fd-12f9-41f8-80e5-3da9b2f9d856";
            try {
                string url = "https://api.zarinpal.com/pg/v4/payment/verify.json?merchant_id=" +
                    merchant + "&amount=" +
                    invoice.Amount.ToString() + "&authority=" +
                    invoice.Authority;
                var client = new RestClient (url);
                client.Timeout = -1;
                var request = new RestRequest (Method.POST);
                request.AddHeader ("accept", "application/json");
                request.AddHeader ("content-type", "application/json");
                IRestResponse response = client.Execute (request);
                Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse (response.Content);
                string data = jodata["data"].ToString ();
                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse (response.Content);
                string errors = jo["errors"].ToString ();
                if (data != "[]") {
                    string refid = jodata["data"]["ref_id"].ToString ();
                    invoice.RefId = refid;
                    invoice.PaymentDate = DateTime.Now;
                    invoice.IsConfirm = true;
                    _context.SaveChanges();
                    return Ok (invoice.Id);
                } else if (errors != "[]") {
                    string errorscode = jo["errors"]["code"].ToString ();
                }
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
            }
            return NotFound ();
        }
    }

}