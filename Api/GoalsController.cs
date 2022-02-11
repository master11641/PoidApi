using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class GoalsController : Controller {
        private BarnamaConntext _context;
        public GoalsController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetGoals")]
        public IActionResult GetGoals () {          
            return Ok (_context.Goals.Select(x=>new{x.Id,x.Title,ImageUrl="/uploads/"+ x.ImageUrl}).ToList());

        }

    }

}