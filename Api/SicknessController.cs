using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class SicknessController : Controller {
        private BarnamaConntext _context;
        public SicknessController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetGoals")]
        public IActionResult GetGoals () {          
            return Ok (_context.Sicknesses.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}