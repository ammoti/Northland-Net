using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northland.Net.Domain;

namespace Northland.Net.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => new { k.UserId});

            builder.Property(p => p.TotalAmount).HasColumnType("money").HasDefaultValueSql("((0))");

             builder.HasOne(s=>s.User).WithMany(p=>p.Orders).HasForeignKey(s=>s.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Order_User");
        }
    }
}