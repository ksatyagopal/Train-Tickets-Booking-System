using BookMyTrainApp.Codes;
using BookMyTrainApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReachCodes reaches = new();
        private readonly StationCodes stations = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LiveStation()
        {
            try
            {
                ViewData["stations"] = new SelectList(stations.List().Result, "StationCode", "StationName");
                return View();
            }
            catch
            {
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Trains Server...";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult LiveStation([Bind("StationCode")] Reach reach)
        {
            ViewData["selected"] = reach.StationCode;
            ViewData["stations"] = new SelectList(stations.List().Result, "StationCode", "StationName", reach.StationCode);
            return View("LiveTrains");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
