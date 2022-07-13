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
    public class TransactionsController : Controller
    {
        private readonly DigitalBankContext _context;

        public TransactionsController(DigitalBankContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var digitalBankContext = _context.Transactions.Include(t => t.FromAccountNavigation).Include(t => t.ToAccountNavigation);
            return View(await digitalBankContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.FromAccountNavigation)
                .Include(t => t.ToAccountNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            var fromacc = long.Parse(HttpContext.Session.GetString("useraccountnumber"));
            var fromaccounts = (from i in _context.Accounts where i.AccountNumber == fromacc && i.AccHolderName != "BookMyTrain" select i);
            ViewData["FromAccount"] = new SelectList(fromaccounts, "AccountNumber", "AccHolderName");
            var toaccounts = (from i in _context.Accounts where i.AccountNumber != fromacc && i.AccHolderName!="BookMyTrain" select i);
            ViewData["ToAccount"] = new SelectList(toaccounts, "AccountNumber", "AccHolderName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FromAccount,ToAccount,TransactionAmount,TransactionReason")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.TransactionType = "D";
                transaction.IsPending = false;
                transaction.TransactionState = true;
                Account toa = _context.Accounts.Find(transaction.ToAccount);
                toa.Balance += transaction.TransactionAmount;
                Account froma = _context.Accounts.Find(transaction.FromAccount);
                froma.Balance -= transaction.TransactionAmount;
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.FromAccount);
            ViewData["ToAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.ToAccount);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["FromAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.FromAccount);
            ViewData["ToAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.ToAccount);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,FromAccount,ToAccount,TransactionDate,TransactionAmount,TransactionType,TransactionReason,TransactionState,IsPending,CurrentBalance")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["FromAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.FromAccount);
            ViewData["ToAccount"] = new SelectList(_context.Accounts, "AccountNumber", "AccHolderName", transaction.ToAccount);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.FromAccountNavigation)
                .Include(t => t.ToAccountNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            transaction.TransactionState = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","UserAccount");
        }

        public async Task<IActionResult> Pay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.FromAccountNavigation)
                .Include(t => t.ToAccountNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Pay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            transaction.IsPending = false;
            _context.Accounts.Find(transaction.FromAccount).Balance -= transaction.TransactionAmount;
            _context.Accounts.Find(transaction.ToAccount).Balance += transaction.TransactionAmount;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "UserAccount");
        }




        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
