using DigitalBankWebAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBankWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DigitalBankContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LogInAsAdminIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogInAsAdminIndex([Bind("UserName,Password")] Admin admin)
        {
            Admin realadmin = (from a in _context.Admins
                               where a.UserName == admin.UserName && a.Password == admin.Password
                               select a).FirstOrDefault();
            HttpContext.Session.SetString("adminusername", realadmin.UserName);

            if (realadmin!=null)
                return RedirectToAction("Index", "Admins");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("adminusername") != null)
                HttpContext.Session.Remove("adminusername");
            if (HttpContext.Session.GetString("username") != null)
                HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
