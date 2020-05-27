using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northland.Net.Domain;

namespace Northland.Net.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => new { k.SupplierId });
            builder.HasOne(s=>s.Supplier).WithMany(p=>p.Products).HasForeignKey(s=>s.SupplierId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Product_Supplier");

            builder.Property(p => p.UnitPrice).HasColumnType("money").HasDefaultValueSql("((0))");
        }
    }
}