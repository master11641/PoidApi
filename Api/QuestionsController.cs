using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class QuestionsController : Controller {
        private BarnamaConntext _context;
        public QuestionsController (BarnamaConntext context) {
            _context = context;
        }

        [HttpGet ("GetQuestions")]
        public IActionResult GetQuestions () {          
            return Ok (_context.Questions.Select(x=>new{x.Id,x.Title}).ToList());

        }

    }

}