using AutoMapper;
using FabricioStore.Interfaces;
using FabricioStore.Models;
using FabricioStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricioStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(await _repository.GetAll());
            return View(model);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<ProductViewModel>(model);

            return View(view);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            var model = _mapper.Map<Product>(viewModel);

            if (!ModelState.IsValid) return View(viewModel);

            _repository.Register(model);

            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<ProductViewModel>(model);

            return View(view);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel view)
        {
            var model = _mapper.Map<Product>(view);

            if (!ModelState.IsValid) return View(model);

            _repository.Update(model);

            ViewBag.Sucesso = "Usuário atualizado!";

             return View(view);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _repository.GetById(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<ProductViewModel>(model);

            return View(view);
        }

        // POST: ProductController/Delete/5
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
