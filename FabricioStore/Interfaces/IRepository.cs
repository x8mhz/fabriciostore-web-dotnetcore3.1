using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FabricioStore.Models;
using FabricioStore.ViewModels;

namespace FabricioStore.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class 
    { 
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid? id);
        Task Register(T view);
        Task Remove(T view);
        Task Update(T view);
    }
}