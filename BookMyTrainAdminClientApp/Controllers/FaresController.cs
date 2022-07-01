using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyTrainAdminClientApp.Models;
using BookMyTrainAdminClientApp.Codes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class FaresController : Controller
    {
        private readonly FareCodes fares = new();
        public void Session(string sessionName, string value)
        {
            HttpContext.Session.SetString(sessionName, value);
        }
        public string? Session(string sessionName)
        {
            return HttpContext.Session.GetString(sessionName);
        }

        // GET: Fares
        public IActionResult Index()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return View("PageNotFound");
            }
            return View(fares.List().Result);
        }

        // GET: Fares/Details/5
        public IActionResult Details(string id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return View("PageNotFound");
            }
            if (id == null)
            {
                return NotFound();
            }

            var fare = fares.GetMoneyByCoachType(id).Result;
            if (fare == null)
            {
                return NotFound();
            }

            return View(fare);
        }

        // GET: Fares/Create
        public IActionResult Create()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return View("PageNotFound");
            }
            return View();
        }

        // POST: Fares/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TypeOfCoach,Fare1")] Fare fare)
        {
            if (ModelState.IsValid)
            {
                var res = fares.AddFare(fare).Result;
                return RedirectToAction(nameof(Index));
            }
            return View(fare);
        }

        // GET: Fares/Edit/5
        public IActionResult Edit(string id)
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return View("PageNotFound");
            }
            if (id == null)
            {
                return NotFound();
            }

            var fare = fares.GetMoneyByCoachType(id).Result;
            if (fare == null)
            {
                return NotFound();
            }
            return View(fare);
        }

        // POST: Fares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("TypeOfCoach,Fare1")] Fare fare)
        {
            if (id != fare.TypeOfCoach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var res = fares.UpdateFare(fare).Result;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FareExists(fare.TypeOfCoach))
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
            return View(fare);
        }

        // GET: Fares/Delete/5
        //public IActionResult Delete(string id)
        //{
        //    if (Session("adminid") == null)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    if (Session("issuperadmin") != true.ToString())
        //    {
        //        return View("PageNotFound");
        //    }
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fare = fares.GetMoneyByCoachType(id);
        //    if (fare == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fare);
        //}

        //// POST: Fares/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(string id)
        //{
        //    var res = fares.DeleteFare(fares.GetMoneyByCoachType(id).Result).Result;
        //    return RedirectToAction(nameof(Index));
        //}

        private bool FareExists(string id)
        {
            return fares.List().Result.Any(e => e.TypeOfCoach == id);
        }
    }
}
