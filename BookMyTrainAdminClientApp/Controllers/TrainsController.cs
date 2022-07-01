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
    public class TrainsController : Controller
    {
        private readonly TrainCodes trains = new();
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
            try
            {
                return View(trains.List().Result);
            }
            catch(Exception)
            {
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Trains Server...";
                return RedirectToAction("Index","Home");
            }
        }

        // GET: Trains/Details/5
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

            var train = trains.GetTrainByNumber((int)id).Result;
            train.TdestinationNavigation = stations.GetStationByCode(train.Tdestination).Result;
            train.TsourceNavigation = stations.GetStationByCode(train.Tsource).Result;
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // GET: Trains/Create
        public IActionResult Create()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["Tdestination"] = new SelectList(stations.List().Result, "StationCode", "StationName");
            ViewData["Tsource"] = new SelectList(stations.List().Result, "StationCode", "StationName");
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TrainNumber,TrainName,Tsource,Tdestination,ArrivalTime,DepartureTime,NAc1Coaches,NAc2Coaches,NAc3Coaches,NSlCoaches,NSsCoaches,NGeneralCoaches,RunsOn,TrainType")] Train train)
        {
            if (ModelState.IsValid)
            {
                train.IsDeleted = false;
                train.AvailableSeats = (train.NAc1Coaches +
                                        train.NAc2Coaches +
                                        train.NAc3Coaches +
                                        train.NSlCoaches +
                                        train.NSsCoaches +
                                        train.NGeneralCoaches)*90;
                var newtrain = trains.AddTrain(train).Result;
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tdestination"] = new SelectList(stations.List().Result, "StationCode", "StationName", train.Tdestination);
            ViewData["Tsource"] = new SelectList(stations.List().Result, "StationCode", "StationName", train.Tsource);
            return View(train);
        }

        // GET: Trains/Edit/5
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

            var train = trains.GetTrainByNumber((int)id).Result;
            if (train == null)
            {
                return NotFound();
            }
            ViewData["Tdestination"] = new SelectList(stations.List().Result, "StationCode", "StationName", train.Tdestination);
            ViewData["Tsource"] = new SelectList(stations.List().Result, "StationCode", "StationName", train.Tsource);
            return View(train);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TrainNumber,TrainName,Tsource,Tdestination,ArrivalTime,DepartureTime,AvailableSeats,NAc1Coaches,NAc2Coaches,NAc3Coaches,NSlCoaches,NSsCoaches,NGeneralCoaches,RunsOn,IsDeleted,TrainType")] Train train)
        {
            if (id != train.TrainNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    train.AvailableSeats = (train.NAc1Coaches +
                                        train.NAc2Coaches +
                                        train.NAc3Coaches +
                                        train.NSlCoaches +
                                        train.NSsCoaches +
                                        train.NGeneralCoaches) * 90;
                    var result = trains.UpdateTrain(train).Result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.TrainNumber))
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
            ViewData["Tdestination"] = new SelectList(stations.List().Result, "StationCode", "StationCode", train.Tdestination);
            ViewData["Tsource"] = new SelectList(stations.List().Result, "StationCode", "StationCode", train.Tsource);
            return View(train);
        }

        // GET: Trains/Delete/5
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
            var train = trains.GetTrainByNumber((int)id).Result;
            train.TdestinationNavigation = stations.GetStationByCode(train.Tdestination).Result;
            train.TsourceNavigation = stations.GetStationByCode(train.Tsource).Result;
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var train = trains.GetTrainByNumber((int)id).Result;
            var res = trains.DeleteTrain(train).Result;
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(int id)
        {
            foreach(var i in trains.List().Result)
            {
                if(i.TrainNumber == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
