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
    public class MenuAddsController : Controller
    {
        private readonly SmartFoodResturantContext _context;

        public MenuAddsController(SmartFoodResturantContext context)
        {
            _context = context;
        }

        // GET: MenuAdds
        public async Task<IActionResult> Index()
        {
            var smartFoodResturantContext = _context.MenuAdd.Include(m => m.Admin);
            return View(await smartFoodResturantContext.ToListAsync());
        }

        // GET: MenuAdds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuAdd = await _context.MenuAdd
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuAdd == null)
            {
                return NotFound();
            }

            return View(menuAdd);
        }

        // GET: MenuAdds/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId");
            return View();
        }

        // POST: MenuAdds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,MenuName,MenuDescription,MenuPriceHalf,MenuPriceFull,MenuUpdatedDate,MenuUpdatedBy,MenuCreatedDate,MenuCreatedBy,MenuStatus,AdminId")] MenuAdd menuAdd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", menuAdd.AdminId);
            return View(menuAdd);
        }

        // GET: MenuAdds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuAdd = await _context.MenuAdd.FindAsync(id);
            if (menuAdd == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", menuAdd.AdminId);
            return View(menuAdd);
        }

        // POST: MenuAdds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,MenuName,MenuDescription,MenuPriceHalf,MenuPriceFull,MenuUpdatedDate,MenuUpdatedBy,MenuCreatedDate,MenuCreatedBy,MenuStatus,AdminId")] MenuAdd menuAdd)
        {
            if (id != menuAdd.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuAdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuAddExists(menuAdd.MenuId))
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
            ViewData["AdminId"] = new SelectList(_context.Admin, "AdminId", "AdminId", menuAdd.AdminId);
            return View(menuAdd);
        }

        // GET: MenuAdds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuAdd = await _context.MenuAdd
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuAdd == null)
            {
                return NotFound();
            }

            return View(menuAdd);
        }

        // POST: MenuAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuAdd = await _context.MenuAdd.FindAsync(id);
            _context.MenuAdd.Remove(menuAdd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuAddExists(int id)
        {
            return _context.MenuAdd.Any(e => e.MenuId == id);
        }
    }
}
