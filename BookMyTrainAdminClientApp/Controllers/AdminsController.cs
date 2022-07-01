using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMyTrainAdminClientApp.Codes;
using BookMyTrainAdminClientApp.Models;
using Microsoft.AspNetCore.Http;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AdminCodes codes = new();
        private readonly ContributionCode cc = new();
        private Contribution contribution;
        public void Session(string sessionName, string value)
        {
            HttpContext.Session.SetString(sessionName, value);
        }
        public string? Session(string sessionName)
        {
            return HttpContext.Session.GetString(sessionName);
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login","Home");
            }
            if (Session("issuperadmin") != true.ToString())
            {
                return View("PageNotFound");
            }
            return View((from i in await codes.List() where i.AdminId.ToString()!=Session("adminid") select i));
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
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

            var admin = await codes.GetAdminById((int)id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
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

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,AdminName,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.IsSuperAdmin = false;
                admin.IsLocked = false;
                admin.IsActive = true;
                admin.IsDeleted = false;
                admin.UnSuccessfulAttempts = 0;
                admin.LastLoggedInDate = null;
                await codes.AddAdmin(admin);
                contribution = new(Convert.ToInt32(Session("adminid")),
                                    admin.UserName,
                                    "Created",
                                    DateTime.Now,
                                    "New Admin");
                var res = cc.AddContribution(contribution).Result;
                Codes.Codes mail = new();
                mail.SendEmail("Granted Admin Access", $"Hello {admin.AdminName},\n {Session("adminname")} has given you admin privileges to his application.", admin.UserName);
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            var admin = await codes.GetAdminById((int)id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("AdminId,UserName,AdminName,IsSuperAdmin,IsActive,IsLocked")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var realadmin = await codes.GetAdminById(admin.AdminId);
                    realadmin.IsActive = admin.IsActive;
                    if (realadmin.IsSuperAdmin == true && admin.IsSuperAdmin == false)
                    {
                        if((from i in codes.List().Result where i.IsSuperAdmin==true select i).ToList().Count == 1)
                        {
                            TempData["typeofmessage"] = "warning";
                            TempData["Message"] = "Not a Valid Operation, Atleast One Admin should be Super Admin";
                            return RedirectToAction("Edit","Admins");
                        }
                        else
                        {
                            realadmin.IsSuperAdmin = admin.IsSuperAdmin;
                            TempData["typeofmessage"] = "success";
                            TempData["Message"] = "Changed Successfully";
                        }
                    }
                    else
                    {
                        realadmin.IsSuperAdmin = admin.IsSuperAdmin;
                    }
                    realadmin.IsLocked = false;
                    if (admin.IsLocked == false)
                    {
                        realadmin.UnSuccessfulAttempts = 0;
                    }
                    await codes.UpdateAdmin(realadmin);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminId))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            var admin = await codes.GetAdminById((int)id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await codes.DeleteAdmin(await codes.GetAdminById(id));
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            var admin = codes.GetAdminById(id);
            if (admin == null)
                return false;
            return true;
        }

        public async Task<IActionResult> Profile()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            
            var admin = await codes.GetAdminById(Convert.ToInt32(Session("adminid")));
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }
    }
}
