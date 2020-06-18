using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class ProducesController : Controller
    {
        private readonly SmartResturantContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public ProducesController(SmartResturantContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

      public IActionResult CancelOrder(String id) {
            
                var order_Find = _context.Order.Find(Int32.Parse(id));
                order_Find.Status = "Cancel";
                _context.SaveChanges();

                return RedirectToAction(nameof(Tablet));        
        }



        [HttpPost]
        public IList<Produce> sidebar(string value)
        {
            if (value == "Menu:")
            {
                return (_context.Produce.ToList());
            }
            else if (value == "FastFood" || value == "DesiFood" || value == "Drinks")
            {
                var searchTopcategory = _context.Produce.Where(a => a.TopCategory.Contains(value)).ToList();
                return (searchTopcategory);

            }
            var searcheddata = _context.Produce.Where(abc => abc.Category.Contains(value)).ToList();
            return (searcheddata);
        }


        // GET: Produces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produce.ToListAsync());

        }


       
        public IActionResult Tablet(string f = "")
        {
            if (f == "")
            {
                return View(_context.Produce.ToList());
            }

            var searcheddata = _context.Produce.Where(abc => abc.Name.Contains(f) || abc.Description.Contains(f)).ToList();

            return View(searcheddata);
        }

        // GET: Produces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // GET: Produces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProduceViewClass produce)
        {
            if (ModelState.IsValid)
            {
                string UniqueFileName = null;
                if (produce.Photo != null)
                {
                    string ImageFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    UniqueFileName = Guid.NewGuid().ToString() + "_" + produce.Photo.FileName;
                    string filePath = Path.Combine(ImageFolder, UniqueFileName);
                    produce.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Produce produce1 = new Produce
                {
                    Name = produce.Name,
                    Id = produce.Id,
                    PhotoUrl = UniqueFileName,
                    Description = produce.Description,
                    PriceFull = produce.PriceFull,
                    PriceHalf = produce.PriceHalf,
                    PriceMedium = produce.PriceMedium,
                    CreatedBy = produce.CreatedBy,
                    CreatedDate = produce.CreatedDate,
                    Category = produce.Category,
                    UpdatedBy = produce.UpdatedBy,
                    TopCategory = produce.TopCategory,
                    UpdatedDate = produce.UpdatedDate,
                    Status = produce.Status
                };
                _context.Add(produce1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(produce);
        }
        // GET: Produces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            return View(produce);
        }

        // POST: Produces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PriceHalf,PriceFull,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Status")] Produce produce)
        {
            if (id != produce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduceExists(produce.Id))
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
            return View(produce);
        }

        // GET: Produces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // POST: Produces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produce = await _context.Produce.FindAsync(id);
            _context.Produce.Remove(produce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduceExists(int id)
        {
            return _context.Produce.Any(e => e.Id == id);
        }
    }
}
