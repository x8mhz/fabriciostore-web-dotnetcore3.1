using FabricioStore.Data.Context;
using FabricioStore.Interfaces;
using FabricioStore.Models;

namespace FabricioStore.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FabricioStoreContext context) : base(context)
        {
        }
    }
}