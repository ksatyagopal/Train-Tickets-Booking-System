using BookMyTrainAdminClientApp.Codes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class ContributionsController : Controller
    {
        private readonly ContributionCode codes = new();
        public void Session(string sessionName, string value)
        {
            HttpContext.Session.SetString(sessionName, value);
        }
        public string? Session(string sessionName)
        {
            return HttpContext.Session.GetString(sessionName);
        }
        public IActionResult Index()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return RedirectToAction("Index", "Admin");
            }
            return View(codes.List().Result);
        }
    }
}
