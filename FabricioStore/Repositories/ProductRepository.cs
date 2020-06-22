using FabricioStore.Data.Context;
using FabricioStore.Interfaces;
using FabricioStore.Models;

namespace FabricioStore.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(FabricioStoreContext context) : base(context)
        {
        }
    }
}