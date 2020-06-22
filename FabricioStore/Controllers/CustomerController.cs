using AutoMapper;
using FabricioStore.Data.Context;
using FabricioStore.Models;
using FabricioStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricioStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FabricioStoreContext _context;
        private readonly IMapper _mapper;

        public CustomerController(FabricioStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: CustomerController
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<CustomerViewModel>>(await _context.Customers.ToListAsync());

            return View(model);
        }

        // GET: CustomerController/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Customers.FindAsync(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<CustomerViewModel>(model);

            return View(view);
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel view)
        {
            var model = _mapper.Map<Customer>(view);

            if (!ModelState.IsValid) return View(view);
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");

        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Customers.FindAsync(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<CustomerViewModel>(model);

            return View(view);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel view)
        {
            var model = _mapper.Map<Customer>(view);

            if (!ModelState.IsValid) return View(view);

            _context.Update(model);
            await _context.SaveChangesAsync();

            ViewBag.Sucesso = "Usuário atualizado!";

            return View(view);
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Customers.FindAsync(id);

            if (model == null) return NotFound();
            var view = _mapper.Map<CustomerViewModel>(model);

            return View(view);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var model = await _context.Customers.FindAsync(id);
            await _context.Customers.Remove(model).GetDatabaseValuesAsync();
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
