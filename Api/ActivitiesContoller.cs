using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class ActivitiesController : Controller {
        private BarnamaConntext _context;
        public ActivitiesController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetActivities")]
        public IActionResult GetActivities () {          
            return Ok (_context.ActivityRates.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}