using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Barnama.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Barnama.Controllers {
    [Authorize (UserInRole = "admin")]
    public class HomeController : Controller {
        private IUserService _userService;
        private IWebHostEnvironment _env;
        private readonly ILogger<HomeController> _logger;

        public HomeController (ILogger<HomeController> logger, IUserService userService, IWebHostEnvironment env) {
            _userService = userService;
            _logger = logger;
            _env = env;
        }

        public IActionResult Index () {
            return View ();
        }
        public IActionResult Details () {
            string path = Path.Combine (this._env.WebRootPath, "uploads\\") + "5b7f8892-8960-4a1b-9ba9-14e7b29e6909.json";
            // var jsonString = System.IO.File.ReadAllLines(path);
            string jsonString = "";
            using (StreamReader reader = System.IO.File.OpenText (path)) {
                jsonString = reader.ReadToEnd ();
            }
            // ExportModel weatherForecast =
            //     JsonSerializer.Deserialize<ExportModel> (jsonString);
            ViewBag.FileModel = jsonString;
            List<ExportModel> model =
                JsonSerializer.Deserialize<List<ExportModel>> (jsonString);

            return View (model);
        }
        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // [Authorize]
        // [HttpGet ("getall")]
        // public IActionResult GetAll () {
        //     var users = _userService.GetAll ();
        //     return Ok (users);
        // }
    }
}