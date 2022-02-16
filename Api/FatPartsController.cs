using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class FatPartsController : Controller {
        private BarnamaConntext _context;
        public FatPartsController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetFatParts")]
        public IActionResult GetFatParts () {
            return Ok (_context.FatParts.Select (x => new { x.Id, x.Title, ImageUrl = "/uploads/" + x.ImageUrl }).ToList ());

        }

        [HttpPost ("AddParts")]
        public IActionResult AddParts (int userId, List<int> id) {          
            var diet = _context.Diets.Include(x=>x.FatPartDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
           if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            if (id != null && id.Count != 0) {
                diet.FatPartDiets.Clear ();
                foreach (int partId in id) {
                    FatPartDiet fatDiet = new FatPartDiet { FatPartId = partId, Diet = diet };
                    diet.FatPartDiets.Add (fatDiet);
                }
            }
            _context.SaveChanges ();
           return Ok(id.Count);
        }

    }

}