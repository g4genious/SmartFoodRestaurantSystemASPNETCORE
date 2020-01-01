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
    public class StocksController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public StocksController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.Stock.Include(s => s.Admin).Include(s => s.Product).Include(s => s.Supplier);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Admin)
                .Include(s => s.Product)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            ViewData["SupplierId"] = new SelectList(_context.SupplierRegistration, "SupplierId", "SupplierId");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,SupplierId,ProductId,AdminId,StockAddedBy,StockAddedDate,StockModifiedDate,StockModifiedBy,UnitPrice,TotalAmount,ProductType,CurrentStock")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", stock.AdminId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", stock.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.SupplierRegistration, "SupplierId", "SupplierId", stock.SupplierId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", stock.AdminId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", stock.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.SupplierRegistration, "SupplierId", "SupplierId", stock.SupplierId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,SupplierId,ProductId,AdminId,StockAddedBy,StockAddedDate,StockModifiedDate,StockModifiedBy,UnitPrice,TotalAmount,ProductType,CurrentStock")] Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockId))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", stock.AdminId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", stock.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.SupplierRegistration, "SupplierId", "SupplierId", stock.SupplierId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Admin)
                .Include(s => s.Product)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.StockId == id);
        }
    }
}
