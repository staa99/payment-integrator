using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DonationsApp.Models;

namespace DonationsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }

        public IActionResult About ()
        {
            ViewData["Message"] = "This is a sample of the Staaworks.PaymentIntegrator.Paystack package.";

            return View();
        }

        public IActionResult Contact ()
        {
            ViewData["Message"] = "I am staa99. +234-708-915-4094";

            return View();
        }

        public IActionResult Privacy ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
