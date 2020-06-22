﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FabricioStore.Data.Context;
using FabricioStore.Models;
using FabricioStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricioStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly FabricioStoreContext _context;
        private readonly IMapper _mapper;
        public ProductController(FabricioStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(await _context.Products.ToListAsync());
            return View(model);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Products.FindAsync(id);

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
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            var model = _mapper.Map<Product>(viewModel);

            if (!ModelState.IsValid) return View(viewModel);

            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Products.FindAsync(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<ProductViewModel>(model);

            return View(view);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            var model = _mapper.Map<Product>(viewModel);

            if (!ModelState.IsValid) return View(viewModel);
             _context.Update(model);
             await _context.SaveChangesAsync();

             ViewBag.Sucesso = "Usuário atualizado!";

             return View(viewModel);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var model = await _context.Products.FindAsync(id);

            if (model == null) return NotFound();

            var view = _mapper.Map<ProductViewModel>(model);

            return View(view);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var model = await _context.Products.FindAsync(id);
            await _context.Products.Remove(model).GetDatabaseValuesAsync();
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}