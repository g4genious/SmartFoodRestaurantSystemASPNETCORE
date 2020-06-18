using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SmartFoodRestaurantSystem.Models;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmartResturantContext _context;

        public HomeController(SmartResturantContext context)
        {
            _context = context;
        }

        public IActionResult Webhome()
        {
            return View();
        }







            public void calculateProfit()
        {
            int loss = 0;
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

            profit = sale - Purchase;    
            loss = sale - Purchase;
            int check = -(profit);
            if (profit != check)
                profit = -(profit);
            ViewBag.Loss = loss;
            ViewBag.Profit = profit;
            ViewBag.Purchase = Purchase;
            ViewBag.Sale = sale;
            
        }
        public IActionResult Index()
        {
            calculateProfit();
            ViewBag.count = _context.Order.Count();

            //FeedBack Count
            SqlConnection connection = new SqlConnection("Server=DESKTOP-OA8I7NE\\SQLEXPRESS;Database=SmartResturant;Trusted_Connection=False;MultipleActiveResultSets=true; User ID=sa; Password=alihassan;");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT count(ID) FROM FeedBack WHERE Service = 'Excellent' OR Environment = 'Excellent' OR Staff = 'Excellent' OR Food  = 'Excellent'";
            ViewBag.excellentPercent = Int32.Parse(cmd.ExecuteScalar().ToString());

            cmd.CommandText = "SELECT count(ID) FROM FeedBack WHERE Service = 'Average' OR Environment = 'Average' OR Staff = 'Average' OR Food  = 'Average'";
            ViewBag.avgPercent = Int32.Parse(cmd.ExecuteScalar().ToString());






            cmd.CommandText = "SELECT count(ID) FROM FeedBack WHERE Service = 'Bad' OR Environment = 'Bad' OR Staff = 'Bad' OR Food  = 'Bad'";
            ViewBag.badPercent = Int32.Parse(cmd.ExecuteScalar().ToString());

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






            connection.Close();

            return View(_context.Order.ToList());
        }

    }
}
