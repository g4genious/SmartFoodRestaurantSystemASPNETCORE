using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class ProductsController : Controller
    {
        string selfAccount = "0524350904";
        private readonly SmartResturantContext _context;

        public ProductsController(SmartResturantContext context)
        {
            _context = context;
        }
        public IActionResult CalculateProfit()
        {

            int profit = 0;
            var TotalSale = _context.OrderList.ToList();
            int sale = 0;
            foreach (var item in TotalSale)
            {
                sale = sale + item.GrandTotal;
            }

            var TotalPurchase = _context.Product.ToList();
            int Purchase = 0;
            foreach (var item in TotalPurchase)
            {
                Purchase = Purchase + item.Paid_Amount;
            }

            if (sale > Purchase)

                profit = sale - Purchase;
            else if (sale < Purchase)
                profit = Purchase - sale;

            ViewBag.Profit = profit;
            ViewBag.Purchase = Purchase;
            ViewBag.Sale = sale;

            SqlConnection connection = new SqlConnection("Server=DESKTOP-OA8I7NE\\SQLEXPRESS;Database=SmartResturant;Trusted_Connection=False;MultipleActiveResultSets=true; User ID=sa; Password=alihassan;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ViewBag.jan = 0;
            ViewBag.feb = 0;
            ViewBag.mar = 0;
            ViewBag.apr = 0;
            ViewBag.may = 0;
            ViewBag.jun = 0;
            ViewBag.jul = 0;
            ViewBag.aug = 0;
            ViewBag.sep = 0;
            ViewBag.oct = 0;
            ViewBag.nov = 0;
            ViewBag.dec = 0;

            cmd.CommandText = "SELECT MONTH(Date) as month, SUM(GrandTotal) as grand_total FROM OrderList GROUP BY MONTH(Date)";
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    switch (rdr["month"].ToString())
                    {
                        case "1":
                            ViewBag.jan = rdr["grand_total"].ToString();
                            break;
                        case "2":
                            ViewBag.feb = rdr["grand_total"].ToString();
                            break;
                        case "3":
                            ViewBag.mar = rdr["grand_total"].ToString();
                            break;
                        case "4":
                            ViewBag.apr = rdr["grand_total"].ToString();
                            break;
                        case "5":
                            ViewBag.may = rdr["grand_total"].ToString();
                            break;
                        case "6":
                            ViewBag.jun = rdr["grand_total"].ToString();
                            break;
                        case "7":
                            ViewBag.jul = rdr["grand_total"].ToString();
                            break;
                        case "8":
                            ViewBag.aug = rdr["grand_total"].ToString();
                            break;
                        case "9":
                            ViewBag.sep = rdr["grand_total"].ToString();
                            break;
                        case "10":
                            ViewBag.oct = rdr["grand_total"].ToString();
                            break;
                        case "11":
                            ViewBag.nov = rdr["grand_total"].ToString();
                            break;
                        case "12":
                            ViewBag.dec = rdr["grand_total"].ToString();
                            break;
                    }
                }
            }

            ViewBag.janp = 0;
            ViewBag.febp = 0;
            ViewBag.marp = 0;
            ViewBag.aprp = 0;
            ViewBag.mayp = 0;
            ViewBag.junp = 0;
            ViewBag.julp = 0;
            ViewBag.augp = 0;
            ViewBag.sepp = 0;
            ViewBag.octp = 0;
            ViewBag.novp = 0;
            ViewBag.decp = 0;

            cmd.CommandText = "SELECT MONTH(Purchase_Date) as month, SUM(Paid_Amount) as Paid_Amount FROM Product GROUP BY MONTH(Purchase_Date)";
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    switch (rdr["month"].ToString())
                    {
                        case "1":
                            ViewBag.janp = rdr["Paid_Amount"].ToString();
                            break;
                        case "2":
                            ViewBag.febp = rdr["Paid_Amount"].ToString();
                            break;
                        case "3":
                            ViewBag.marp = rdr["Paid_Amount"].ToString();
                            break;
                        case "4":
                            ViewBag.aprp = rdr["Paid_Amount"].ToString();
                            break;
                        case "5":
                            ViewBag.mayp = rdr["Paid_Amount"].ToString();
                            break;
                        case "6":
                            ViewBag.junp = rdr["Paid_Amount"].ToString();
                            break;
                        case "7":
                            ViewBag.julp = rdr["Paid_Amount"].ToString();
                            break;
                        case "8":
                            ViewBag.augp = rdr["Paid_Amount"].ToString();
                            break;
                        case "9":
                            ViewBag.sepp = rdr["Paid_Amount"].ToString();
                            break;
                        case "10":
                            ViewBag.octp = rdr["Paid_Amount"].ToString();
                            break;
                        case "11":
                            ViewBag.novp = rdr["Paid_Amount"].ToString();
                            break;
                        case "12":
                            ViewBag.decp = rdr["Paid_Amount"].ToString();
                            break;
                    }
                }
            }


            connection.Close();
            return View();
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var smartResturantContext = _context.Product.Include(p => p.Category).Include(p => p.Supplier);
            return View(await smartResturantContext.ToListAsync());
        }
        //Purchase Report
        public async Task<IActionResult> PurchaseReport(DateTime? dateTo, DateTime? dateFrom)
        {
            if (dateTo == null && dateFrom == null)
            {
                var smartResturantContext = _context.Product.Include(p => p.Category).Include(p => p.Supplier);

                return View(await smartResturantContext.ToListAsync());
            }
            else
            {
                var x = _context.Product.Include(p => p.Category).Include(p => p.Supplier).Where(t =>
                (!dateFrom.HasValue || t.PurchaseDate >= dateFrom) && (!dateTo.HasValue || t.PurchaseDate <= dateTo)).ToList();

                return View(x);

            }

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category).Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            ViewData["CategoryName"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["SupplierName"] = new SelectList(_context.Supplier, "Id", "Name");
            return View();
        }
        public int getStockQuantity(string value)
        {
            var x = _context.Product.Find(Int32.Parse(value));
            var y = x.Quantity;
            return y;
        }
        public int getProductStockQuantity(string value)
        {
            var x = _context.Product.Where(t => t.Name == value).FirstOrDefault();
            var y = 0;
            if (x != null)
            {
                y = x.Quantity;
                return y;
            }
            else
                return y = 0;

        }
        [HttpPost]

        public void addStock(Product item1)
        {
            //check purchase Item Exit in product Table or not 
            var isItemExit = _context.Product.Where(temp => temp.Name == item1.Name).FirstOrDefault();
            //check Purchase Item Exit in Stock Table or not
            var isItemExitInStock = _context.Stock.Where(temp => temp.ProductName == item1.Name).FirstOrDefault();
            //if Item Exit in Product Table Then Do this
            if (isItemExit != null)
            {
                isItemExit.SubTotal += item1.SubTotal;
                isItemExit.Total += item1.Total;
                isItemExit.Quantity += item1.Quantity;
                isItemExit.Rate = item1.Rate;
                _context.SaveChanges();
                //if Item Exit in Stock then Do this
                if (isItemExitInStock != null)
                {
                    isItemExitInStock.In_Quantity += item1.Quantity;
                    _context.SaveChanges();
                }
            }
            //if Item is not exit in product then Do This
            else if (isItemExit == null)
            {
                item1.PurchaseDate = DateTime.Now.Date;
                _context.Add(item1);
                _context.SaveChanges();
                Product product = new Product();
                var findProduct = _context.Product.Where(t => t.Name == item1.Name).FirstOrDefault();
                var productId = findProduct.Id;
                //if item exit in stock  then Do this
                if (isItemExitInStock != null)
                {
                    isItemExitInStock.In_Quantity += item1.Quantity;
                    _context.SaveChanges();
                }
                //if item is not exit in stock then Do this
                else if (isItemExitInStock == null)
                {
                    try
                    {
                        Stock s = new Stock();
                        s.In_Quantity = item1.Quantity;
                        s.ProductName = item1.Name;
                        s.ProductId = productId;
                        _context.Add(s);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        public void DualEntry(Product item1)
        {
            var IsSupplierEntryExist = _context.SupplierAccount.Where(t => t.SupplierId == item1.SupplierId).ToList();
            var SupplierName = _context.Supplier.Find(item1.SupplierId);
            var LastBalance = 0;
            if (IsSupplierEntryExist.Count != 0)
            {
                var LastRecord = IsSupplierEntryExist.LastOrDefault();
                LastBalance = LastRecord.Balance;
            }
            if (item1.Payment_Type == "Cash")
            {
                SupplierAccount account = new SupplierAccount();
                account.SupplierId = item1.SupplierId;
                account.Date = DateTime.Now;
                account.SupplierName = SupplierName.Name;
                account.Credit = item1.Total;
                account.Debit = 0;
                account.Balance = LastBalance - item1.Total;
                _context.Add(account);
                _context.SaveChanges();

                SupplierAccount account1 = new SupplierAccount();
                account1.SupplierId = item1.SupplierId;
                account1.SupplierName = SupplierName.Name;
                account1.Date = DateTime.Now;
                account1.Debit = item1.Paid_Amount;
                account1.Credit = 0;
                account1.Balance = account.Balance + item1.Paid_Amount;
                _context.Add(account1);
                _context.SaveChanges();

            }
            else if (item1.Payment_Type == "Due")
            {
                SupplierAccount account = new SupplierAccount();
                account.SupplierId = item1.SupplierId;
                account.SupplierName = SupplierName.Name;
                account.Date = DateTime.Now;
                account.Credit = item1.Total;
                account.Debit = 0;
                account.Balance = LastBalance - item1.Total;
                _context.Add(account);
                _context.SaveChanges();

            }
        }
        public IActionResult Create(IList<Product> product)
        {
          //  if (ModelState.IsValid)
           // {
                int count = 0;
                foreach (Product item1 in product)
                {
                    count++;
                    addStock(item1);
                    if (count == product.Count)
                    {
                        DualEntry(item1);
                        LegerEntry(item1);
                    }
                }
           // }
            return View();
        }

        private void LegerEntry(Product item1)
        {
            Ledger ledger = new Ledger();
            ledger.Date = System.DateTime.Now.Date;
            ledger.Description = "";
            var searchSupplier = _context.Supplier.Where(t => t.Id == item1.SupplierId).FirstOrDefault().PhoneNumber;
            var search = _context.Account.Where(t => t.ID == searchSupplier).FirstOrDefault();
            if (item1.Payment_Type == "Cash")
            {
                ledger.PaymentType = "Debit";
                ledger.SourceAccount = selfAccount;
                ledger.DestinationAccount = search.ID;
                ledger.Amount = -item1.Paid_Amount;
                _context.Add(ledger);
                _context.SaveChanges();
            }
            else if (item1.Payment_Type == "Due")
            {
                ledger.PaymentType = "Credit";
                ledger.SourceAccount = search.ID;
                ledger.DestinationAccount = selfAccount;
                ledger.Amount = item1.Total;
                _context.Add(ledger);
                _context.SaveChanges();
            }
        }

        public string StockQuantityUpdate(int value, int product)
        {
            var product_Item = _context.Product.Find(product);
            product_Item.Quantity = value;
            _context.SaveChanges();
            return "1";
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Id", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Id", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category).Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}