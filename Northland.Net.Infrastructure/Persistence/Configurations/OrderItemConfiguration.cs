using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northland.Net.Domain;

namespace Northland.Net.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<Domain.OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(k => new { k.OrderId, k.ProductId });

            builder.Property(p => p.UnitPrice).HasColumnType("money").HasDefaultValueSql("((0))");

            builder.Property(p => p.Quantity).HasDefaultValueSql("((1))");

             builder.HasOne(s=>s.Order).WithMany(p=>p.OrderItems).HasForeignKey(s=>s.OrderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Order_Item_Order");

              builder.HasOne(s=>s.Product).WithMany(p=>p.OrderItems).HasForeignKey(s=>s.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Order_Item_Product");
        }
    }
}