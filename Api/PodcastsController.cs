using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class PodcastController : Controller {
        private BarnamaConntext _context;
        public PodcastController (BarnamaConntext context) {
            _context = context;
        }

        [HttpGet ("GetPodcastGroups")]
        public IActionResult GetPodcastGroups () {
            return Ok (_context.PodcastGroups.Select (x => new {
                x.Id,
                    x.Title,
                    x.ImageUrl,

            }));

        }

        [HttpPost ("GetPodcastByGroupId")]
        public IActionResult GetPodcastByGroupId (int groupId) {
            return Ok (_context.Podcasts.Where (x => x.PodcastGroupId == groupId).Select (x => new {
                x.Id,
                    x.Title,
                    x.PodcastAudio
            }));

        }
    }

}