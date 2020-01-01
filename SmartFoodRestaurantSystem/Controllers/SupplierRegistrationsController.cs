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
    public class SupplierRegistrationsController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public SupplierRegistrationsController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: SupplierRegistrations
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.SupplierRegistration.Include(s => s.Admin);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: SupplierRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRegistration = await _context.SupplierRegistration
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplierRegistration == null)
            {
                return NotFound();
            }

            return View(supplierRegistration);
        }

        // GET: SupplierRegistrations/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            return View();
        }

        // POST: SupplierRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,SupplierPhoneNumber,SupplierCompany,AdminId")] SupplierRegistration supplierRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", supplierRegistration.AdminId);
            return View(supplierRegistration);
        }

        // GET: SupplierRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRegistration = await _context.SupplierRegistration.FindAsync(id);
            if (supplierRegistration == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", supplierRegistration.AdminId);
            return View(supplierRegistration);
        }

        // POST: SupplierRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,SupplierName,SupplierPhoneNumber,SupplierCompany,AdminId")] SupplierRegistration supplierRegistration)
        {
            if (id != supplierRegistration.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierRegistrationExists(supplierRegistration.SupplierId))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", supplierRegistration.AdminId);
            return View(supplierRegistration);
        }

        // GET: SupplierRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierRegistration = await _context.SupplierRegistration
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplierRegistration == null)
            {
                return NotFound();
            }

            return View(supplierRegistration);
        }

        // POST: SupplierRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierRegistration = await _context.SupplierRegistration.FindAsync(id);
            _context.SupplierRegistration.Remove(supplierRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierRegistrationExists(int id)
        {
            return _context.SupplierRegistration.Any(e => e.SupplierId == id);
        }
    }
}
