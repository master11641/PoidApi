using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class SportsController : Controller {
        private BarnamaConntext _context;
        public SportsController (BarnamaConntext context) {
            _context = context;
        }

        [HttpGet ("GetSportGroups")]
        public IActionResult GetSportGroups () {
            return Ok (_context.SportGroups.Select (x => new {
                   x.Id,
                    x.Title,
                    x.ImageUrl,
            }));
        }//GetSportGroups
        [HttpPost ("GetSports")]
        public IActionResult GetSports (int GroupId) {
            return Ok (_context.Sports.Where(x=>x.SportGroupId==GroupId).Select (x => new {
                   x.Id,
                    x.Title,
                    x.ImageUrl,
            }));
        }//GetSports
        [HttpPost ("GetSportItems")]
        public IActionResult GetSportItems (int SportId) {
            return Ok (_context.SportItems.Where(x=>x.SportId==SportId).Select (x => new {
                   x.Id,
                    x.Title,
              x.Description,
              x.DescriptionAudio,
              x.DescriptionVideo
            }));
        }//GetSportItems

    }//SportsController

}