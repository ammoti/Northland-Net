using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northland.Net.Domain;

namespace Northland.Net.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Domain.Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(c=> c.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(ct=>ct.ContactTitle).HasMaxLength(100).IsRequired();
        }
    }
}