using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northland.Net.Domain;
namespace Northland.Net.Application.Common.Interfaces
{
    public interface INorthlandDbContext
    {
        DbSet<Domain.User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Domain.OrderItem> OrderItems { get; set; }
        DbSet<Domain.Product> Products { get; set; }
        DbSet<Domain.Supplier> Suppliers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}