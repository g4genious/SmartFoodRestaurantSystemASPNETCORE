using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartFoodRestaurantSystem.Controllers
{
    public class WebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Receipes()
        {
            return View();
        }
    }
}