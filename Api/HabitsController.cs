using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class HabitsController : Controller {
        private BarnamaConntext _context;
        public HabitsController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetHabits")]
        public IActionResult GetHabits () {          
            return Ok (_context.BadHabits.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}