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

        public async Task Register(T view)
        { 
            await _db.AddAsync(view);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T view)
        {
            await _db.Update(view).GetDatabaseValuesAsync();
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T view)
        {
            await _db.Remove(view).GetDatabaseValuesAsync();
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}