using System;
using FabricioStore.Models;

namespace FabricioStore.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>, IDisposable
    {
    }
}