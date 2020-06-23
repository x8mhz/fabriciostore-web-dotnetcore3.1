using FabricioStore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using FabricioStore.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FabricioStore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FabricioStoreContext _context;
        private readonly DbSet<T> _db;

        public Repository(FabricioStoreContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.ToListAsync();
        }

        public async Task<T> GetById(Guid? id)
        {
            return await _db.FindAsync(id);
        }

        public async void Register(T view)
        {
            await _db.AddAsync(view);
            _context.SaveChanges();
        }

        public void Update(T view)
        {
            _db.Update(view);
            _context.SaveChanges();
        }

        public void Remove(T view)
        {
            _db.Remove(view);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _context.Dispose();

        }
    }
}