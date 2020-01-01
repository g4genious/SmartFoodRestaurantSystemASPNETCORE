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
    public class CustomerRegistrationsController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public CustomerRegistrationsController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: CustomerRegistrations
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.CustomerRegistration.Include(c => c.Table);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: CustomerRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRegistration = await _context.CustomerRegistration
                .Include(c => c.Table)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerRegistration == null)
            {
                return NotFound();
            }

            return View(customerRegistration);
        }

        // GET: CustomerRegistrations/Create
        public IActionResult Create()
        {
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId");
            return View();
        }

        // POST: CustomerRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerPhoneNumber,TableId")] CustomerRegistration customerRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", customerRegistration.TableId);
            return View(customerRegistration);
        }

        // GET: CustomerRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRegistration = await _context.CustomerRegistration.FindAsync(id);
            if (customerRegistration == null)
            {
                return NotFound();
            }
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", customerRegistration.TableId);
            return View(customerRegistration);
        }

        // POST: CustomerRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,CustomerPhoneNumber,TableId")] CustomerRegistration customerRegistration)
        {
            if (id != customerRegistration.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRegistrationExists(customerRegistration.CustomerId))
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
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", customerRegistration.TableId);
            return View(customerRegistration);
        }

        // GET: CustomerRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRegistration = await _context.CustomerRegistration
                .Include(c => c.Table)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerRegistration == null)
            {
                return NotFound();
            }

            return View(customerRegistration);
        }

        // POST: CustomerRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerRegistration = await _context.CustomerRegistration.FindAsync(id);
            _context.CustomerRegistration.Remove(customerRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerRegistrationExists(int id)
        {
            return _context.CustomerRegistration.Any(e => e.CustomerId == id);
        }
    }
}
