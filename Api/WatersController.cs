using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class WatersController : Controller {
        private BarnamaConntext _context;
        public WatersController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetWaters")]
        public IActionResult GetWaters () {          
            return Ok (_context.WaterRates.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}