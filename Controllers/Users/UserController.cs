using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Barnama.Controllers.Users {
    public class UserController : Controller {
        private readonly BarnamaConntext _context;
        private readonly IUserService _userService;
        public UserController (BarnamaConntext context, IUserService userService) {
            _context = context;
            _userService = userService;
        }

        // GET: User
        public async Task<IActionResult> Index () {
            var barnamaConntext = _context.Users;
            return View (await barnamaConntext.ToListAsync ());
        }
        public DataSourceResult GetUsers () {
            var dataString = this.HttpContext.GetJsonDataFromQueryString ();
            var request = JsonConvert.DeserializeObject<DataSourceRequest> (dataString);

            var list = _context.Users;
            return list.AsQueryable ()
                .ToDataSourceResult (request.Take, request.Skip, request.Sort, request.Filter);
        }
        // GET: User/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var user = await _context.Users

                .FirstOrDefaultAsync (m => m.Id == id);
            if (user == null) {
                return NotFound ();
            }

            return View (user);
        }

        // GET: User/Create
        public IActionResult Create () {
            // ViewData["FieldId"] = new SelectList (_context.Fields, "Id", "Id");
            return View ();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Id,Name,Family,FcmToken,PhoneNumber,Password,FieldId")] User user) {
            if (ModelState.IsValid) {
                _context.Add (user);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            // ViewData["FieldId"] = new SelectList (_context.Fields, "Id", "Id", user.FieldId);
            return View (user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var user = await _context.Users.FindAsync (id);
            if (user == null) {
                return NotFound ();
            }
            var SelectedRoles = _context.UserRoles.Where (x => x.UserId == id).Select (x => x.RoleId).ToArray ();
            ViewData["SelectedRoles"] = SelectedRoles;
            return View (user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int Id, string Name, string Family, string FcmToken, string PhoneNumber, string Password, int FieldId, List<int> RoleIds) {
            // var user = _context.Users.Find (Id);
            var user = _context.Users
                .Include (x => x.UserRoles)
                .FirstOrDefault (x => x.Id == Id);
            if (user == null) {
                return NotFound ();
            }
            user.UserRoles.Clear ();
            foreach (int roleId in RoleIds) {
                UserRole userRole = new UserRole { RoleId = roleId, User = user };
                user.UserRoles.Add (userRole);

            }
            if (ModelState.IsValid) {
                try {
                    user.Name = Name;
                    user.Family = Family;

                    _context.Update (user);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!UserExists (user.Id)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            //ViewData["FieldId"] = new SelectList (_context.Fields, "Id", "Id", user.FieldId);
            return View (user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync (m => m.Id == id);
            if (user == null) {
                return NotFound ();
            }

            return View (user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var user = await _context.Users.FindAsync (id);
            _context.Users.Remove (user);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool UserExists (int id) {
            return _context.Users.Any (e => e.Id == id);
        }
        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        public async Task<IActionResult> Login (AuthenticateRequest request) {
            var user = _context.Users.FirstOrDefault (x => x.PhoneNumber == request.Username && x.Password == request.Password);
            if (user == null) {
                ViewBag.Error = "نام کاربری یا پسورد اشتباه است .";
                return View (request);
            } else {
                string token = await _userService.AuthenticateAsync (request);
                var cookieOptions = new CookieOptions () {
                    Path = "/",
                    Expires = DateTimeOffset.UtcNow.AddDays (10),
                    IsEssential = true,
                    HttpOnly = false,
                    Secure = false,
                };
                Response.Cookies.Append ("Authorization", token, cookieOptions);
            }
            return RedirectToAction (controllerName: "Home", actionName: "Index");
        }

        [HttpGet]
        public IActionResult LogOff (AuthenticateRequest request) {
            foreach (var cookie in Request.Cookies.Keys) {
                Response.Cookies.Delete (cookie);
            }
            return RedirectToAction (controllerName: "User", actionName: "Login");
        }

    }
}