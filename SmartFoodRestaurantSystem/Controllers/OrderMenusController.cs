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
    public class OrderMenusController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public OrderMenusController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: OrderMenus
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.OrderMenu.Include(o => o.Table);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: OrderMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenu
                .Include(o => o.Table)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (orderMenu == null)
            {
                return NotFound();
            }

            return View(orderMenu);
        }

        // GET: OrderMenus/Create
        public IActionResult Create()
        {
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId");
            return View();
        }

        // POST: OrderMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,MenuName,MenuDescription,MenuPriceHalf,MenuPriceFull,MenuQuantity,TableId")] OrderMenu orderMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", orderMenu.TableId);
            return View(orderMenu);
        }

        // GET: OrderMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenu.FindAsync(id);
            if (orderMenu == null)
            {
                return NotFound();
            }
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", orderMenu.TableId);
            return View(orderMenu);
        }

        // POST: OrderMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,MenuName,MenuDescription,MenuPriceHalf,MenuPriceFull,MenuQuantity,TableId")] OrderMenu orderMenu)
        {
            if (id != orderMenu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderMenuExists(orderMenu.MenuId))
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
            ViewData["TableId"] = new SelectList(_context.OrderTable, "TableId", "TableId", orderMenu.TableId);
            return View(orderMenu);
        }

        // GET: OrderMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderMenu = await _context.OrderMenu
                .Include(o => o.Table)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (orderMenu == null)
            {
                return NotFound();
            }

            return View(orderMenu);
        }

        // POST: OrderMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderMenu = await _context.OrderMenu.FindAsync(id);
            _context.OrderMenu.Remove(orderMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMenuExists(int id)
        {
            return _context.OrderMenu.Any(e => e.MenuId == id);
        }
    }
}
