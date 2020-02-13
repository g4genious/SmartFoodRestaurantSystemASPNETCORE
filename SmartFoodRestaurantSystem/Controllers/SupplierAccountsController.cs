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
    public class SupplierAccountsController : Controller
    {
        private readonly SmartResturantContext _context;

        public SupplierAccountsController(SmartResturantContext context)
        {
            _context = context;
        }

        // GET: SupplierAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupplierAccount.ToListAsync());
        }

        // GET: SupplierAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAccount = await _context.SupplierAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplierAccount == null)
            {
                return NotFound();
            }

            return View(supplierAccount);
        }

        // GET: SupplierAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId")] SupplierAccount supplierAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierAccount);
        }

        // GET: SupplierAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAccount = await _context.SupplierAccount.FindAsync(id);
            if (supplierAccount == null)
            {
                return NotFound();
            }
            return View(supplierAccount);
        }

        // POST: SupplierAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupplierId")] SupplierAccount supplierAccount)
        {
            if (id != supplierAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierAccountExists(supplierAccount.Id))
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
            return View(supplierAccount);
        }

        // GET: SupplierAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAccount = await _context.SupplierAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplierAccount == null)
            {
                return NotFound();
            }

            return View(supplierAccount);
        }

        // POST: SupplierAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierAccount = await _context.SupplierAccount.FindAsync(id);
            _context.SupplierAccount.Remove(supplierAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierAccountExists(int id)
        {
            return _context.SupplierAccount.Any(e => e.Id == id);
        }
    }
}
