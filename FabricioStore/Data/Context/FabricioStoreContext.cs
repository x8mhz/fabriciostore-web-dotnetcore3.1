using FabricioStore.Data.Mappings;
using FabricioStore.Models;
using Microsoft.EntityFrameworkCore;
using FabricioStore.ViewModels;

namespace FabricioStore.Data.Context
{
    public class FabricioStoreContext : DbContext
    {
        public FabricioStoreContext(DbContextOptions<FabricioStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FabricioStoreDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FabricioStore.ViewModels.ProductViewModel> ProductViewModel { get; set; }

        public DbSet<FabricioStore.ViewModels.CustomerViewModel> CustomerViewModel { get; set; }
    }
}