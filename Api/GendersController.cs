using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class GendersController : Controller {
        private BarnamaConntext _context;
        public GendersController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetGenders")]
        public IActionResult GetGenders () {          
            return Ok (_context.Genders.Select(x=>new{x.Id,x.Title,ImageUrl="/uploads/"+ x.ImageUrl}).ToList());

        }

    }

}