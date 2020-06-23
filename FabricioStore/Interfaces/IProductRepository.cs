using System;
using FabricioStore.Models;

namespace FabricioStore.Interfaces
{
    public interface IProductRepository : IRepository<Product>, IDisposable
    {
    }
}