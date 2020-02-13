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
    public class OrderListsController : Controller
    {
        private readonly SmartResturantContext _context;

        public OrderListsController(SmartResturantContext context)
        {
            _context = context;
        }

        // GET: OrderLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderList.ToListAsync());
        }

        // GET: OrderLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderList == null)

            {
                return NotFound();
            }

            return View(orderList);
        }

        // GET: OrderLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,TableNumber,Date,TotalAmount,OrderID,Discount,ServiceCharges,GrandTotal")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderList);
        }
        public IActionResult Show(int id)
        {
            {
                IList<OrderListViewDB> Receipt = (from c in _context.OrderList
                                                  where id == c.Id
                                                  join od in _context.OrderDetail on id equals od.OrderId
                                                  select new OrderListViewDB
                                                  {
                                                      itemName = od.Name,
                                                      Quantity = od.Quantity,
                                                      Price = od.Price,
                                                      SubTotal = od.SubTotal
                                                  }).ToList<OrderListViewDB>();
                var TotalAmount = (from c in _context.OrderList
                                   where id == c.Id
                                   select new OrderListViewDB
                                   {
                                       TotalAmount = c.TotalAmount,
                                       Discount = c.Discount,
                                       ServiceCharges = c.ServiceCharges,
                                       GrandTotal = c.GrandTotal
                                   });
                ViewBag.Totals = TotalAmount;

                return View(Receipt);
            }
        }


        // GET: OrderLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return NotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,TableNumber,Date,TotalAmount,OrderID,Discount,ServiceCharges,GrandTotal")] OrderList orderList)
        {
            if (id != orderList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderListExists(orderList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
           
            }
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderList == null)
            {
                return NotFound();
            }

            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderList = await _context.OrderList.FindAsync(id);
            _context.OrderList.Remove(orderList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderListExists(int id)
        {
            return _context.OrderList.Any(e => e.Id == id);
        }
    }
}










