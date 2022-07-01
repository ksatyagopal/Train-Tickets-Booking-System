using BookMyTrainAdminClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookMyTrainAdminClientApp.Codes;
using Microsoft.AspNetCore.Http;

namespace BookMyTrainAdminClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdminCodes codes = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
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
            return View(codes.GetAdminById(Convert.ToInt32(Session("adminid"))).Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            if(Session("adminid")==null)
            {
                return View("Login");
            }
            if (Session("issuperadmin") == true.ToString())
            {
                return View();
            }
            return View("PageNotFound");
        }

        public IActionResult Login()
        {
            if (Session("adminid") == null)
            {
                TempData["Message"] = null;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                TempData["typeofmessage"] = "failed";
                var admin = codes.isValidAdmin(username, password).Result;

                if (admin == null)
                {
                    TempData["Message"] = "Entered UserName or Password are wrong.";
                }
                else
                {
                    if (admin.IsLocked == true)
                    {
                        TempData["Message"] = "Sorry, You are Locked.";
                    }
                    else if(admin.IsActive == false)
                    {
                        TempData["Message"] = "Sorry, You are InActive.";
                    }
                    else if (admin.Password == password)
                    {
                        Session("adminid", admin.AdminId.ToString());
                        Session("adminname", admin.AdminName);
                        Session("issuperadmin", admin.IsSuperAdmin.ToString());
                        TempData["typeofmessage"] = "success";
                        TempData["Message"] = $"Hello {admin.AdminName}!, Last Logged on {admin.LastLoggedInDate:dd/MM/yyyy(HH:mm)}";
                        admin.UnSuccessfulAttempts = 0;
                        admin.LastLoggedInDate = DateTime.Now;
                        var result = codes.UpdateAdmin(admin).Result;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        if (admin.UnSuccessfulAttempts >= 3)
                        {
                            admin.IsLocked = true;
                            var result = codes.UpdateAdmin(admin).Result;
                            TempData["Message"] = "Sorry, You are Locked.";
                        }
                        else
                        {
                            admin.UnSuccessfulAttempts = admin.UnSuccessfulAttempts + 1;
                            var result1 = codes.UpdateAdmin(admin).Result;
                            TempData["Message"] = $"Login Failed, you have {3 - admin.UnSuccessfulAttempts} attempts left.";
                        }
                    }
                }
                return View();
            }
            catch(Exception){
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Server...";
                return View();
            }
        }

        public IActionResult Logout()
        {
            if (Session("adminid") == null)
            {
                return RedirectToAction("Login","Home");
            }
            HttpContext.Session.Remove("adminid");
            HttpContext.Session.Clear();
            TempData["typeofmessage"] = "success";
            TempData["Message"] = "Successfully Logged Out";
            return View("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string username)
        {
            var padmins = codes.List().Result;
            if (padmins.Any(a => a.UserName == username))
            {
                Random random = new();
                Codes.Codes mail = new();
                var otp = random.Next(111111, 999999).ToString();
                var fpwdadmin = padmins.Find(a => a.UserName == username);
                TempData["fpwdadmin"] = fpwdadmin.AdminId;
                var subject = $"BookMyTrain Account - {otp} is your verification code for secure access";
                var mailbody = $"Hi {fpwdadmin.AdminName},\n\n" +
                    $"We are sharing a verification code to access your account." +
                    $"\nOnce verified you are redirected to reset your password." +
                    $"\n\nYour OTP: {otp}\n\n" +
                    $"Note: If you haven't raised this request please contact superiors as soon as possible.\n" +
                    $"\nBest Regards,\nBookMyTrain Team";
                mail.SendEmail(subject, mailbody, username);
                Session("otp", otp);
                TempData["otp"] = otp;
                return RedirectToAction("VerifyOTP","Home");
            }
            TempData["typeofmessage"] = "failed";
            TempData["Message"] = "Username not found";
            return RedirectToAction("Login", "Home");
        }

        public IActionResult VerifyOTP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VerifyOTP(Verify verify)
        {
            var otp = Session("otp").ToString();
            if (otp != verify.OTP)
            {
                TempData["fpwdadmin"] = null;
                TempData["otp"] = null;
                TempData["typeofmessage"] = "failed";
                TempData["Message"] = "Sorry, Unable to process now.";
                return RedirectToAction("Login", "Home");
            }
            return View("ResetPassword");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string password)
        {
            if (TempData["fpwdadmin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var adminid = Convert.ToInt32(TempData["fpwdadmin"]);
            Admin admin = codes.GetAdminById(adminid).Result;
            admin.Password = password;
            var res = codes.UpdateAdmin(admin).Result;
            TempData["fpwdadmin"] = null;
            TempData["typeofmessage"] = "success";
            TempData["Message"] = "Password Changed Successfully, Login Now...";
            return View("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
