using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalBankWebAppMVC.Models;
using Microsoft.AspNetCore.Http;

namespace DigitalBankWebAppMVC.Controllers
{
    public class AccountLoginsController : Controller
    {
        private readonly DigitalBankContext _context;

        public AccountLoginsController(DigitalBankContext context)
        {
            _context = context;
        }


        
        // GET: AccountLogins/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: AccountLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,SecurityQuestion,SecurityQanswer,LastLoggedInDate,Password")] AccountLogin accountLogin)
        {
            if (ModelState.IsValid)
            {
                if (AccountLoginExists(accountLogin.UserName))
                {
                    return View();
                }
                _context.Add(accountLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","UserAccount");
            }
            return View(accountLogin);
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin([Bind("UserName,Password")] AccountLogin accountLogin)
        {
            if (accountLogin != null && AccountLoginExists(accountLogin.UserName))
            {
                AccountLogin acc = _context.AccountLogins.Find(accountLogin.UserName);
                if(acc.Password == accountLogin.Password)
                {
                    HttpContext.Session.SetString("username", acc.UserName);
                    HttpContext.Session.SetString("useraccountnumber", acc.AccountNumber.ToString());
                    HttpContext.Session.SetString("lastlogindate", acc.LastLoggedInDate.ToString());
                    HttpContext.Session.SetString("loginstatus", "Success");
                    acc.LastLoggedInDate = DateTime.Now;
                    _context.SaveChanges();
                    return RedirectToAction("Index","UserAccount");
                }
                HttpContext.Session.SetString("loginstatus", "Failed");
                return View();
            }
            HttpContext.Session.SetString("loginstatus", "Failed");
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View("ResetPwdEnterUsername");
        }

        public IActionResult ResetPassword(string username)
        {
            if(AccountLoginExists(username))
                return View("ResetPwdSecurityQ");
            return View("Index");
        }
        
        [HttpPost]
        public IActionResult ResetPassword(string username, string password, string confirmPassword)
        {
            if(password == confirmPassword)
            {
                _context.AccountLogins.Find(username).Password = password;
                _context.SaveChanges();
                
            }
            return View("Index");
        }

        private bool AccountLoginExists(string id)
        {
            return _context.AccountLogins.Any(e => e.UserName == id);
        }
    }
}
