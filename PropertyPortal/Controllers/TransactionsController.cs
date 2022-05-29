using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;

namespace PropertyPortal.Controllers
{
    [Authorize]
    public class TransactionsController : ControllerBase
    {

        public TransactionsController(IUnitOfWork uow, UserManager<ApplicationUser> userManager) : base(uow, userManager)
        {
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var appUser = await GetUser();
            return View(_uow.Transactions.GetTransactionsByUserId(appUser.IsAdministrator, appUser.Id));
        }

        // GET: Transactions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _uow.Transactions.GetTransactionById(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create()
        {
            var appUser = await GetUser();

            ViewData["PropertyId"] = new SelectList(_uow.Properties.GetPropertiesByUserId(appUser.Id), "PropertyId", "PropertyName");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,PropertyId,UserId,TransactionDate")] Transaction transaction)
        {
            var appUser = await GetUser();

            transaction.UserId = appUser.Id;

            if (ModelState.IsValid)
            {
                await _uow.Transactions.Add(transaction);
                _uow.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_uow.Properties.GetPropertiesByUserId(appUser.Id), "PropertyId", "PropertyName");
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _uow.Transactions.Get(id.Value);
            if (transaction == null)
            {
                return NotFound();
            }

            var appUser = await GetUser();

            ViewData["PropertyId"] = new SelectList(_uow.Properties.GetPropertiesByUserId(appUser.Id), "PropertyId", "PropertyName");
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,PropertyId,UserId,TransactionDate")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Transactions.Update(transaction);
                    _uow.Complete();
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
            var appUser = await GetUser();

            ViewData["PropertyId"] = new SelectList(_uow.Properties.GetPropertiesByUserId(appUser.Id), "PropertyId", "PropertyName");
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _uow.Transactions.Get(id.Value);

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
            _uow.Transactions.Delete(id);
            _uow.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _uow.Transactions.Get(id) != null;        }
    }
}
