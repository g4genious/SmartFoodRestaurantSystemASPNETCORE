using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly SmartResturantContext _context;

        public OrdersController(SmartResturantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DinningTables()
        {
            return View();
        }
        // GET: GoingOrders
        public async Task<IActionResult> GoingOrder()
        {
            return View(await _context.Order.ToListAsync());
        }

      



        public IActionResult DinningTablesPost(int id)
        {
            HttpContext.Session.SetInt32("TableNumber", id);
            return RedirectToAction("Create", "Customers");
        }

        public IActionResult Show(int id)
        {
            IList<OrderDetailViewDB> Details = (from d in _context.OrderDetail
                                                where id == d.OrderId
                                                select new OrderDetailViewDB
                                                {
                                                    Name = d.Name,
                                                    Quantity = d.Quantity,
                                                    Price = d.Price,
                                                    SubTotal = d.SubTotal

                                                }).ToList<OrderDetailViewDB>();

            return View(Details);
        }


        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
       

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }
   [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {

            if (ModelState.IsValid)
            {
                order.TableNumber = HttpContext.Session.GetInt32("TableNumber");
                order.Date = DateTime.Now;
                _context.Add(order);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("id", order.Id.ToString());
                return RedirectToAction("Tablet", "Produces");
            }
            return View(order);
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubTotal,Quantity,TableNumber,Date,ProduceId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
