using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class StaffRegistrationsController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public StaffRegistrationsController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: StaffRegistrations
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.StaffRegistration.Include(s => s.Admin);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: StaffRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRegistration = await _context.StaffRegistration
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffRegistration == null)
            {
                return NotFound();
            }

            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            return View();
        }

        // POST: StaffRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,StaffName,StaffAddress,StaffCnic,StaffPhoneNumber,StaffJobStartDate,StaffJobEndDate,StaffRole,StaffShiftTime,AdminId")] StaffRegistration staffRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", staffRegistration.AdminId);
            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRegistration = await _context.StaffRegistration.FindAsync(id);
            if (staffRegistration == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", staffRegistration.AdminId);
            return View(staffRegistration);
        }

        // POST: StaffRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,StaffAddress,StaffCnic,StaffPhoneNumber,StaffJobStartDate,StaffJobEndDate,StaffRole,StaffShiftTime,AdminId")] StaffRegistration staffRegistration)
        {
            if (id != staffRegistration.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRegistrationExists(staffRegistration.StaffId))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", staffRegistration.AdminId);
            return View(staffRegistration);
        }

        // GET: StaffRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffRegistration = await _context.StaffRegistration
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffRegistration == null)
            {
                return NotFound();
            }

            return View(staffRegistration);
        }

        // POST: StaffRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffRegistration = await _context.StaffRegistration.FindAsync(id);
            _context.StaffRegistration.Remove(staffRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRegistrationExists(int id)
        {
            return _context.StaffRegistration.Any(e => e.StaffId == id);
        }
    }
}
