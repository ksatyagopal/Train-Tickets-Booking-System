using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBankWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBankWebAppMVC.Controllers
{
    public class UserAccountController : Controller
    {
        private DigitalBankContext _context = new();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");
                AccountLogin user = (from i in _context.AccountLogins
                                     where i.UserName == username
                                     select i).FirstOrDefault();

                if(user.AccountNumber == null)
                {
                    return View("UserWithNoAccount");
                }
                var pUser = _context.Accounts.Find(user.AccountNumber);
                return View(pUser);
            }
            else
            {
                return RedirectToAction("UserLogin", "AccountLogins");
            }
        }

        public IActionResult UnderConstruction()
        {
            return View();
        }

        public IActionResult ListTransactions()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");
                AccountLogin user = (from i in _context.AccountLogins
                                     where i.UserName == username
                                     select i).FirstOrDefault();

                ViewBag.username = user.UserName;
                ViewBag.accnum = user.AccountNumber;
                ViewBag.allTransactions = (from i in _context.Transactions.Include(t => t.FromAccountNavigation).Include(t => t.ToAccountNavigation)
                                           where (i.IsPending==false && (i.FromAccount == user.AccountNumber || i.ToAccount == user.AccountNumber) && i.TransactionState==true)
                                           select i).ToList();
                int count = 0;
                foreach(var item in ViewBag.allTransactions)
                {
                    count = count + 1;
                }
                ViewBag.TransactionCount = count;
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "AccountLogins");
            }
        }

        public IActionResult ListPendingTransactions()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");
                AccountLogin user = (from i in _context.AccountLogins
                                     where i.UserName == username
                                     select i).FirstOrDefault();

                ViewBag.username = user.UserName;
                ViewBag.accnum = user.AccountNumber;
                ViewBag.allTransactions = (from i in _context.Transactions.Include(t => t.FromAccountNavigation).Include(t => t.ToAccountNavigation)
                                           where (i.IsPending == true && i.FromAccount == user.AccountNumber)
                                           select i).ToList();
                int count = 0;
                foreach (var item in ViewBag.allTransactions)
                {
                    count = count + 1;
                }
                ViewBag.TransactionCount = count;
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "AccountLogins");
            }
        }

        public IActionResult CreateAccount()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");
                AccountLogin user = (from i in _context.AccountLogins
                                     where i.UserName == username
                                     select i).FirstOrDefault();
                ViewBag.AccountType = _context.AccountTypes;

                if (user.AccountNumber == null)
                {
                    return View();
                }
                else
                    return View("Index");
            }
            else
            {
                return RedirectToAction("UserLogin", "AccountLogins");
            }
        }

        [HttpPost]
        public IActionResult CreateAccount([Bind("AccHolderName,Mobile,Dob,ResidenceAddress,AccountType,Balance")]Account account)
        {
            try
            {
                account.IsActive = false;
                _context.Accounts.Add(account);
                _context.SaveChanges();
                AccountLogin alogin = _context.AccountLogins.Find(HttpContext.Session.GetString("username"));
                Account acc = (from e in _context.Accounts
                               where e.Mobile == account.Mobile
                               select e).FirstOrDefault();
                alogin.AccountNumber = acc.AccountNumber;
                _context.SaveChanges();
                HttpContext.Session.SetString("useraccountnumber", acc.AccountNumber.ToString());
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("CreateAccount");
            }
        }
    }
}
