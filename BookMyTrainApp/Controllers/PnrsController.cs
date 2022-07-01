using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyTrainApp.Codes;
using BookMyTrainApp.Models;
using Microsoft.AspNetCore.Http;

namespace BookMyTrainApp.Controllers
{
    public class PnrsController : Controller
    {
        private readonly PnrCodes pnrs = new();
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
            if (Session("userid") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View(pnrs.List().Result);
        }
    }
}
