using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalBankWebAppMVC.Models;

namespace DigitalBankWebAppMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DigitalBankContext _context;

        public AccountsController(DigitalBankContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var digitalBankContext = _context.Accounts.Include(a => a.AccountTypeNavigation).Include(a => a.ApprovedByNavigation);
            return View(await digitalBankContext.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.AccountTypeNavigation)
                .Include(a => a.ApprovedByNavigation)
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["AccountType"] = new SelectList(_context.AccountTypes, "TypeNumber", "TypeNumber");
            ViewData["ApprovedBy"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNumber,AccHolderName,Mobile,Dob,ResidenceAddress,AccountType,CreationDate,ApprovedBy,ApprovedDate,IsActive,Balance")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountType"] = new SelectList(_context.AccountTypes, "TypeNumber", "TypeNumber", account.AccountType);
            ViewData["ApprovedBy"] = new SelectList(_context.Admins, "AdminId", "AdminId", account.ApprovedBy);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["AccountType"] = new SelectList(_context.AccountTypes, "TypeNumber", "TypeNumber", account.AccountType);
            ViewData["ApprovedBy"] = new SelectList(_context.Admins, "AdminId", "AdminId", account.ApprovedBy);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AccountNumber,AccHolderName,Mobile,Dob,ResidenceAddress,AccountType,CreationDate,ApprovedBy,ApprovedDate,IsActive,Balance")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountNumber))
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
            ViewData["AccountType"] = new SelectList(_context.AccountTypes, "TypeNumber", "TypeNumber", account.AccountType);
            ViewData["ApprovedBy"] = new SelectList(_context.Admins, "AdminId", "AdminId", account.ApprovedBy);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.AccountTypeNavigation)
                .Include(a => a.ApprovedByNavigation)
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(long id)
        {
            return _context.Accounts.Any(e => e.AccountNumber == id);
        }
    }
}
