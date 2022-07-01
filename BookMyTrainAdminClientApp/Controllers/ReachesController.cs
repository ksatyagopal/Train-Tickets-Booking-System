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
    public class ReachesController : Controller
    {
        private readonly ReachCodes reaches = new();
        private readonly ContributionCode contribitions = new();
        private readonly StationCodes stations = new();
        private readonly TrainCodes trains = new();
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
            var ss = stations.List().Result;
            var ts = trains.List().Result;
            var rs = reaches.List().Result;
            foreach (var item in rs)
            {
                item.StationCodeNavigation = ss.Find(s => s.StationCode == item.StationCode);
                item.TrainNumberNavigation = ts.Find(s => s.TrainNumber == item.TrainNumber);
            }
            return View(rs);
        }
        // GET: Reaches/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reach = reaches.List().Result.FirstOrDefault(m => m.Id == id);
            if (reach == null)
            {
                return NotFound();
            }

            return View(reach);
        }

        // GET: Reaches/Create
        public IActionResult Create()
        {
            ViewData["StationCode"] = new SelectList(stations.List().Result, "StationCode", "StationName");
            ViewData["TrainNumber"] = new SelectList(trains.List().Result, "TrainNumber", "TrainNumber");
            return View();
        }

        // POST: Reaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TrainNumber,StationCode,ArrivalTime")] Reach reach)
        {
            if (ModelState.IsValid)
            {
                var res = reaches.AddReach(reach).Result;
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationCode"] = new SelectList(stations.List().Result, "StationCode", "StationName", reach.StationCode);
            ViewData["TrainNumber"] = new SelectList(trains.List().Result, "TrainNumber", "TrainNumber", reach.TrainNumber);
            return View(reach);
        }

        // GET: Reaches/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reach = reaches.List().Result.Find(r => r.Id == id);
            if (reach == null)
            {
                return NotFound();
            }
            ViewData["StationCode"] = new SelectList(stations.List().Result, "StationCode", "StationName", reach.StationCode);
            ViewData["TrainNumber"] = new SelectList(trains.List().Result, "TrainNumber", "TrainNumber", reach.TrainNumber);
            return View(reach);
        }

        // POST: Reaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,TrainNumber,StationCode,ArrivalTime")] Reach reach)
        {
            if (id != reach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var res = reaches.UpdateReach(reach).Result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReachExists(reach.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationCode"] = new SelectList(stations.List().Result, "StationCode", "StationName", reach.StationCode);
            ViewData["TrainNumber"] = new SelectList(trains.List().Result, "TrainNumber", "TrainNumber", reach.TrainNumber);
            return View(reach);
        }

        // GET: Reaches/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reach = reaches.List().Result.FirstOrDefault(m => m.Id == id);
            if (reach == null)
            {
                return NotFound();
            }

            return View(reach);
        }

        // POST: Reaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reach = reaches.List().Result.Find(r => r.Id == id);
            var res = reaches.DeleteReach(reach);
            return RedirectToAction(nameof(Index));
        }

        private bool ReachExists(int id)
        {
            return reaches.List().Result.Any(e => e.Id == id);
        }
    }
}
