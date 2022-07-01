using BookMyTrainApp.Codes;
using BookMyTrainApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainApp.Controllers
{
    public class UsersController : Controller
    {
        UserCodes users = new();
        Codes.Codes codes = new();
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
            return View("Index","Home");
        }

        public IActionResult Register()
        {
          
            if (Session("userid") == null)
            {
                return View();
            }
            return View("PageNotFound");
        }

        [HttpPost]
        public IActionResult Register([Bind("FirstName,LastName,AdharNumber,Gender,Age,Mobile,MailId,City,State,Pincode,SecurityQuestion,SecQuesAnswer,Password")]User user)
        {
            user.IsDeleted = false;
            user.LastLoggedInDate = null;
            user.Password = codes.Hash(user.Password);
            var res = users.AddUser(user).Result;
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            if (Session("adminid") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Users");
        }

     

        [HttpPost]
        public IActionResult Login([Bind("MailId,Password")]User luser)
        {
            try
            {
                TempData["typeofmessage"] = "failed";
                var user = users.List().Result.Find(u=>u.MailId==luser.MailId && codes.Verify(luser.Password, u.Password));

                if (user == null)
                {
                    TempData["Message"] = "Entered UserName or Password are wrong.";
                }
                else
                {
                        Session("userid", user.UserId.ToString());
                        Session("username", user.FirstName+" "+user.LastName);
                        TempData["typeofmessage"] = "success";
                        TempData["Message"] = $"Hello {user.FirstName}!, Last Logged on {user.LastLoggedInDate:dd/MM/yyyy(HH:mm)}";
                        user.LastLoggedInDate = DateTime.Now;
                        var result = users.UpdateUser(user).Result;
                        if (TempData["tNumber"] != null)
                        {
                            return RedirectToAction("ConfirmBooking", "BookTicket");
                        }
                        return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch (Exception e)
            {
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Server...";
                return View();
            }
        }

        public IActionResult Logout()
        {
            if (Session("userid") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Clear();
            TempData["tNumber"] = null;
            TempData["typeofmessage"] = "success";
            TempData["Message"] = "Successfully Logged Out";
            return View("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword([Bind("MailId")]User user)
        {
            try { 
            var pusers = users.List().Result;
            if (pusers.Any(a => a.MailId == user.MailId))
            {
                Random random = new();
                var otp = random.Next(111111, 999999).ToString();
                var fpwduser = pusers.Find(a => a.MailId == user.MailId);
                TempData["fpwduser"] = fpwduser.UserId;
                var subject = $"BookMyTrain Account - {otp} is your verification code for secure access";
                var mailbody = $"Hi {fpwduser.FirstName},\n\n" +
                    $"We are sharing a verification code to access your account." +
                    $"\nOnce verified you are redirected to reset your password." +
                    $"\n\nYour OTP: {otp}\n\n" +
                    $"Note: If you haven't raised this request please contact superiors as soon as possible.\n" +
                    $"\nBest Regards,\nBookMyTrain Team";
                codes.SendEmail(subject, mailbody, user.MailId);
                Session("otp", otp);
                TempData["otp"] = otp;
                return RedirectToAction("VerifyOTP", "Users");
            }
            TempData["typeofmessage"] = "failed";
            TempData["Message"] = "MailId not found";
            return RedirectToAction("Register", "Users");
            }
            catch (Exception e)
            {
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Server...";
                return View();
            }
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
            if (TempData["fpwduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userid = Convert.ToInt32(TempData["fpwduser"]);
            User user = users.GetUserByID(userid).Result;
            user.Password = codes.Hash(password);
            var res = users.UpdateUser(user).Result;
            TempData["fpwduser"] = null;
            TempData["typeofmessage"] = "success";
            TempData["Message"] = "Password Changed Successfully, Login Now...";
            return View("Login");
        }
    }
}
