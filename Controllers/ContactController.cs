using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contact_Management_Web_App.Data;
using Contact_Management_Web_App.ViewModels;
using Contact_Management_Web_App.IServices;

namespace Contact_Management_Web_App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        // GET: contactViewModels
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetAll());
        }

        // GET: contactViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _service.GetById(id.Value);
            if (contactViewModel == null)
            {
                return NotFound();
            }

            return View(contactViewModel);
        }

        // GET: contactViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: contactViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContactNumber,Email")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(contactViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(contactViewModel);
        }

        // GET: contactViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _service.GetById(id.Value);
            if (contactViewModel == null)
            {
                return NotFound();
            }
            return View(contactViewModel);
        }

        // POST: contactViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactNumber,Email")] ContactViewModel contactViewModel)
        {
            if (id != contactViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(contactViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contactViewModelExists(contactViewModel.Id))
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
            return View(contactViewModel);
        }

        // GET: contactViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactViewModel = await _service.GetById(id.Value);
            if (contactViewModel == null)
            {
                return NotFound();
            }

            return View(contactViewModel);
        }

        // POST: contactViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'ApplicationDbContext.contactViewModel'  is null.");
            }
            var contactViewModel = await _service.GetById(id);
            if (contactViewModel != null)
            {
                await _service.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool contactViewModelExists(int id)
        {
          return _service.GetById(id) != null;
        }
    }
}
