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
    public class SalesController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public SalesController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.Sale.Include(s => s.Admin).Include(s => s.Order).Include(s => s.Product);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Admin)
                .Include(s => s.Order)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,OrderId,Date,ProductId,ProductName,ProductSoldOut,ProductRemain,SaleReportCreatedBy,SaleReportCreatedDate,SaleReportModifiedBy,SaleReportModifiedDate,AdminId")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", sale.AdminId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sale.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", sale.AdminId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sale.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sale.ProductId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,OrderId,Date,ProductId,ProductName,ProductSoldOut,ProductRemain,SaleReportCreatedBy,SaleReportCreatedDate,SaleReportModifiedBy,SaleReportModifiedDate,AdminId")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", sale.AdminId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", sale.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Admin)
                .Include(s => s.Order)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.SaleId == id);
        }
    }
}
