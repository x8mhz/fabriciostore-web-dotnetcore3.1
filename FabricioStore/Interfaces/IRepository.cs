using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricioStore.Interfaces
{
    public interface IRepository<T> where T : class 
    { 
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid? id);
        void Register(T view);
        void Update(T view);
        void Remove(T view);
    }
}