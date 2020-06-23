using AutoMapper;
using FabricioStore.Interfaces;
using FabricioStore.Models;
using FabricioStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricioStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: CustomerController
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<CustomerViewModel>>(await _repository.GetAll());

            return View(model);
        }

        // GET: CustomerController/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

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
        public IActionResult Create(CustomerViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var model =_mapper.Map<Customer>(viewModel);

            _repository.Register(model);

            return RedirectToAction("Index");
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<CustomerViewModel>(model);

            return View(view);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel view)
        {
            if (!ModelState.IsValid) return View(view);

            var model = _mapper.Map<Customer>(view);

            _repository.Update(model);

            return View(view);
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<CustomerViewModel>(model);

            return View(view);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var model = await _repository.GetById(id);

            _repository.Remove(model);

           return RedirectToAction("Index");
        }
    }
}
