using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class PropertiesController : ControllerBase
    {

        public PropertiesController(IUnitOfWork uow, UserManager<ApplicationUser> userManager) : base(uow, userManager)
        {

        }

        // GET: Properties
        public async Task<ActionResult> Index()
        {
            var appUser = await GetUser();
            return View(_uow.Properties.GetPropertiesByUserId(appUser.IsAdministrator, appUser.Id));
        }

        // GET: Properties/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = _uow.Properties.GetPropertyById(id.Value);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,PropertyName,Bedroom,IsAvailable,SalePrice,LeasePrice,UserId")] Property @property)
        {
            var appUser = await GetUser();

            property.UserId = appUser.Id;
            if (ModelState.IsValid)
            {

                await _uow.Properties.Add(property);
                _uow.Complete();
                return RedirectToAction(nameof(Index));
            }
            
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _uow.Properties.Get(id.Value);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropertyId,PropertyName,Bedroom,IsAvailable,SalePrice,LeasePrice,UserId")] Property @property)
        {
            if (id != @property.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Properties.Update(property);

                    _uow.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.PropertyId))
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
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _uow.Properties.Get(id.Value);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _uow.Properties.Delete(id);
            _uow.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _uow.Properties.Get(id) != null;
        }
    }
}
