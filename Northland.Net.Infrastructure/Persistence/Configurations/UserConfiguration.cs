using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northland.Net.Domain;

namespace Northland.Net.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();
            builder.Property(n => n.Name).HasMaxLength(100).IsRequired();
            builder.Property(r => r.Roles).HasDefaultValue(1);
            builder.Property(i => i.ImageUrl).HasDefaultValue("profile.jpg");
        }
    }
}