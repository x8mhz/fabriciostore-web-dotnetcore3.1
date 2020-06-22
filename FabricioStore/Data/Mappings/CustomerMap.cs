using FabricioStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricioStore.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnName("Nome")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("Sobrenome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Document)
                .HasColumnName("Cpf")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Senha")
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}