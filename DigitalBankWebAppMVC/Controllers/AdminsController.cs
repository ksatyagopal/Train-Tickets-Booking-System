using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DigitalBankWebAppMVC.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("adminusername")!=null)
                return View();
            return RedirectToAction("LogInAsAdminIndex", "Home");
        }
    }
}
