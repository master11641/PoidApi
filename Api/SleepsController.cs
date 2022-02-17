using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class SleepController : Controller {
        private BarnamaConntext _context;
        public SleepController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetSleeps")]
        public IActionResult GetSleeps () {          
            return Ok (_context.SleepRates.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}