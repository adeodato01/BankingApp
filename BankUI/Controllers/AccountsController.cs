using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingAppMarch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        
         // GET: Accounts
        public IActionResult Index()
        {
            return View(Bank.GetAllAccountsForUser(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public IActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Deposit(IFormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Withdraw(IFormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["amount"]);
            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transactions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = Bank.GetTransactionsForAccountNumber(id.Value);
            return View(transactions);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmailAddress,AccountType")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.EmailAddress, account.AccountType);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AccountNumber,EmailAddress,AccountType")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Bank.UpdateAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (Bank.GetAccountByAccountNumber(account.AccountNumber) == null)
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
            return View(account);
        }
    }
}
