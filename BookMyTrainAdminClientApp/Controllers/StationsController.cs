using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMyTrainAdminClientApp.Codes;
using BookMyTrainAdminClientApp.Models;
using Microsoft.AspNetCore.Http;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class StationsController : Controller
    {
        private readonly StationCodes stations = new();
        private readonly ContributionCode contributions = new();
        private Contribution contribute;
        public void Session(string sessionName, string value)
        {
            HttpContext.Session.SetString(sessionName, value);
        }
        public string? Session(string sessionName)
        {
            return HttpContext.Session.GetString(sessionName);
        }
        // GET: Stations
        public IActionResult Index()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(stations.List().Result);
        }

        // GET: Stations/Details/5
        public IActionResult Details(string id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var station = stations.GetStationByCode(id).Result;
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StationCode,StationName,StationLocation,HaultTime,IsDeleted")] Station station)
        {
            if (ModelState.IsValid)
            {
                station.IsDeleted = false;
                var res = stations.AddStation(station).Result;
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        // GET: Stations/Edit/5
        public IActionResult Edit(string id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var station = stations.GetStationByCode(id).Result;
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("StationCode,StationName,StationLocation,HaultTime,IsDeleted")] Station station)
        {
            if (id != station.StationCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var res = stations.UpdateStation(station).Result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.StationCode))
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
            return View(station);
        }

        // GET: Stations/Delete/5
        public IActionResult Delete(string id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return NotFound();
            }

            var station = stations.GetStationByCode(id).Result;
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var station = stations.GetStationByCode(id).Result;
            var res = stations.DeleteStation(station).Result;
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(string id)
        {
            return stations.List().Result.Any(e => e.StationCode == id);
        }
    }
}
