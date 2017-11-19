using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CreditReport.Controllers
{
    public class HomeController : Controller
    {
         
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Quienes Somos y Que Hacemos.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Informaciones para contactarnos.";

            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }
        


        public IActionResult Error()
        {
            return View();
        }
    }
}
