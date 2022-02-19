using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class ProteinsController : Controller {
        private BarnamaConntext _context;
        public ProteinsController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetProteins")]
        public IActionResult GetProteins () {          
            return Ok (_context.Proteins.Select(x=>new{x.Id,x.Title,ImageUrl="/uploads/"+ x.ImageUrl}).ToList());

        }

    }

}