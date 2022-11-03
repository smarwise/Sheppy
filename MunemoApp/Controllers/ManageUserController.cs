using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MunemoApp.Data;
using MunemoApp.Models.Domain;

namespace MunemoApp.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageUser
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.userDetails.Include(u => u.users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ManageUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.userDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.userDetails
                .Include(u => u.users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // GET: ManageUser/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.users, "Id", "Password");
            return View();
        }

        // POST: ManageUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,FirstName,LastName,DateOfBirth,Province,Gender,Facilitator")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.users, "Id", "Password", userDetails.UserId);
            return View(userDetails);
        }

        // GET: ManageUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.userDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.userDetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.users, "Id", "Password", userDetails.UserId);
            return View(userDetails);
        }

        // POST: ManageUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,FirstName,LastName,DateOfBirth,Province,Gender,Facilitator")] UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailsExists(userDetails.Id))
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
            ViewData["UserId"] = new SelectList(_context.users, "Id", "Password", userDetails.UserId);
            return View(userDetails);
        }

        // GET: ManageUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.userDetails == null)
            {
                return NotFound();
            }

            var userDetails = await _context.userDetails
                .Include(u => u.users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: ManageUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.userDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.userDetails'  is null.");
            }
            var userDetails = await _context.userDetails.FindAsync(id);
            if (userDetails != null)
            {
                _context.userDetails.Remove(userDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailsExists(int id)
        {
          return _context.userDetails.Any(e => e.Id == id);
        }
    }
}
