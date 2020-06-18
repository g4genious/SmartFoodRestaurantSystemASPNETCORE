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
        private readonly SmartResturantContext _context;

        public StocksController(SmartResturantContext context)
        {
            _context = context;
        }
        public IActionResult StockReport(string data = "")
        {
            if (data == "")
            {
                return View(_context.Stock.ToList());
            }

            var searcheddata = _context.Stock.Where(t => t.ProductName.Contains(data)).ToList();

            return View(searcheddata);

        }
        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var smartResturantContext = _context.Stock.Include(p => p.Product);
            return View(await smartResturantContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stock = await _context.Stock.Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProductName"] = new SelectList(_context.Product, "Id", "Name");
        //    return View();
        //}

        //// POST: Stocks/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Stock stock1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product_Name = _context.Product.Find(stock1.ProductId);
        //        stock1.ProductName = product_Name.Name;
        //        _context.Add(stock1);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductName"] = new SelectList(_context.Stock, "Id", "Name", stock1.ProductId);
        //    return View(stock1);
        //}

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
            var item_Stock = _context.Product.Find(stock.ProductId);
            ViewBag.stockQuantity = item_Stock.Quantity;

            ViewData["ProductName"] = new SelectList(_context.Stock, "Id", "Id", stock.ProductId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stock stock1)
        {
            if (id != stock1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //var getProduct_Item = _context.Product.Find(stock1.ProductId);
                //int update_Quantity = getProduct_Item.Quantity - stock1.stock;
                try
                {
                    var item_Stock = _context.Product.Find(stock1.ProductId);
                    stock1.In_Quantity = item_Stock.Quantity;
                    stock1.ProductName = item_Stock.Name;
                    _context.Update(stock1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock1.Id))
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
            ViewData["ProductName"] = new SelectList(_context.Stock, "Id", "Id", stock1.ProductId);
            return View(stock1);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Stock.Any(e => e.Id == id);
        }
    }
}