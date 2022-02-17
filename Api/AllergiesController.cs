using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class AllergiesController : Controller {
        private BarnamaConntext _context;
        public AllergiesController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetAllergies")]
        public IActionResult GetAllergies () {          
            return Ok (_context.Allergies.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}