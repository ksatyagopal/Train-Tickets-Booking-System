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
    public class StationDistancesController : Controller
    {
        private readonly StationDistanceCodes stdists = new();
        private readonly ContributionCode contribitions = new();
        private readonly StationCodes stations = new();
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
            var sds = stdists.List().Result;
            foreach(var item in sds)
            {
                item.StationANavigation = ss.Find(s => s.StationCode == item.StationA);
                item.StationBNavigation = ss.Find(s => s.StationCode == item.StationB);
            }
            return View(sds);
        }

        // GET: StationDistances/Details/5
        public IActionResult Details(int? id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var stationDistance = stdists.List().Result.FirstOrDefault(m => m.Id == id);
            stationDistance.StationANavigation = stations.List().Result.Find(m => m.StationCode == stationDistance.StationA);
            stationDistance.StationBNavigation = stations.List().Result.Find(m => m.StationCode == stationDistance.StationB);

            if (stationDistance == null)
            {
                return NotFound();
            }

            return View(stationDistance);
        }

        // GET: StationDistances/Create
        public IActionResult Create()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["StationA"] = new SelectList(stations.List().Result, "StationCode", "StationName");
            ViewData["StationB"] = new SelectList(stations.List().Result, "StationCode", "StationName");
            return View();
        }

        // POST: StationDistances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StationA,StationB,Distance")] StationDistance stationDistance)
        {
            if (ModelState.IsValid)
            {
                var res = stdists.AddStationDistance(stationDistance).Result;
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationA"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationA);
            ViewData["StationB"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationB);
            return View(stationDistance);
        }

        // GET: StationDistances/Edit/5
        public IActionResult Edit(int? id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var stationDistance = stdists.List().Result.Find(s=>s.Id == id);
            if (stationDistance == null)
            {
                return NotFound();
            }
            ViewData["StationA"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationA);
            ViewData["StationB"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationB);
            return View(stationDistance);
        }

        // POST: StationDistances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StationA,StationB,Distance")] StationDistance stationDistance)
        {
            if (id != stationDistance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var res = stdists.UpdateStationDistance(stationDistance).Result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationDistanceExists(stationDistance.Id))
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
            ViewData["StationA"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationA);
            ViewData["StationB"] = new SelectList(stations.List().Result, "StationCode", "StationName", stationDistance.StationB);
            return View(stationDistance);
        }

        // GET: StationDistances/Delete/5
        public IActionResult Delete(int? id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var stationDistance = stdists.List().Result.FirstOrDefault(m => m.Id == id);
            stationDistance.StationANavigation = stations.List().Result.Find(m=>m.StationCode == stationDistance.StationA);
            stationDistance.StationBNavigation = stations.List().Result.Find(m => m.StationCode == stationDistance.StationB);
            if (stationDistance == null)
            {
                return NotFound();
            }

            return View(stationDistance);
        }

        // POST: StationDistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var stationDistance = stdists.List().Result.Find(s=>s.Id == id);
            var res = stdists.DeleteStationDistance(stationDistance).Result;
            return RedirectToAction(nameof(Index));
        }

        private bool StationDistanceExists(int id)
        {
            return stdists.List().Result.Any(e => e.Id == id);
        }
    }
}
