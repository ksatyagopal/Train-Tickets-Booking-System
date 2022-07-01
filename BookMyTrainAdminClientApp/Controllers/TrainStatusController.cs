using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyTrainAdminClientApp.Codes;
using BookMyTrainAdminClientApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class TrainStatusController : Controller
    {
        private readonly TrainStatusCodes tstatus = new();
        private readonly ContributionCode contribitions = new();
        private Contribution contribute;
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
            return View(tstatus.List().Result);
        }

        // GET: TrainStatus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainStatus = tstatus.List().Result.FirstOrDefault(m => m.tsId == id);
            if (trainStatus == null)
            {
                return NotFound();
            }

            return View(trainStatus);
        }
    }
}
