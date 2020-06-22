using FabricioStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricioStore.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnName("Titulo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Brand)
                .HasColumnName("Marca")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Category)
                .HasColumnName("Categoria")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("Valor")
                .IsRequired();
        }
    }
}