using System;

namespace FabricioStore.Models
{
    public class Product
    {
        protected Product() { }

        public Product(string title, string category, string brand, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Category = category;
            Brand = brand;
            Price = price;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
        public string Brand { get; private set; }
        public decimal Price { get; private set; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}