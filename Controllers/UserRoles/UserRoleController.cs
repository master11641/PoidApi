using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Barnama.Controllers.UserRoles
{
    public class UserRoleController : Controller
    {
        private readonly BarnamaConntext _context;

        public UserRoleController(BarnamaConntext context)
        {
            _context = context;
        }

        // GET: UserRole
        public async Task<IActionResult> Index()
        {
            var barnamaConntext = _context.UserRoles.Include(u => u.Role).Include(u => u.User);
            return View(await barnamaConntext.ToListAsync());
        }

        // GET: UserRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles
                .Include(u => u.Role)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // GET: UserRole/Create
        public IActionResult Create(int? userId)
        {
            if(userId==null){
             ViewData["UserId"] = new SelectList(_context.Users, "Id", "PhoneNumber");
            }else{
                 ViewData["UserId"] = new SelectList(_context.Users.Where(x=>x.Id==userId).ToList(), "Id", "PhoneNumber");
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Title");
           
            return View();
        }

        // POST: UserRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Title", userRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "PhoneNumber", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRole/Edit/5
        public async Task<IActionResult> Edit(int? userId,int? roleId)
        {
            if (userId == null || roleId ==null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.Where(x=>x.UserId==userId && x.RoleId==roleId).FirstAsync();
            if (userRole == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Title", userRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "PhoneNumber", userRole.UserId);
            return View(userRole);
        }

        // POST: UserRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,RoleId")] UserRole userRole)
        {
            if (id != userRole.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userRole.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", userRole.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRole/Delete/5
        public async Task<IActionResult> Delete(int? userId,int? roleId)
        {
           if (userId == null || roleId ==null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.Where(x=>x.UserId==userId && x.RoleId==roleId).FirstAsync();
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // POST: UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? userId,int? roleId)
        {
           var userRole = await _context.UserRoles.Where(x=>x.UserId==userId && x.RoleId==roleId).FirstAsync();
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRoleExists(int id)
        {
            return _context.UserRoles.Any(e => e.UserId == id);
        }
    }
}
