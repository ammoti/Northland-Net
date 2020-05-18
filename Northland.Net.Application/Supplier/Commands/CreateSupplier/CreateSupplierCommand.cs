using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.Supplier.Commands.CreateSupplier
{
    public partial class CreateSupplierCommand : IRequest<long>
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }

    }
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, long>
    {
        private readonly INorthlandDbContext _context;
        public CreateSupplierCommandHandler(INorthlandDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {

            var entity = new Northland.Net.Domain.Supplier()
            {
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Phone = request.Phone,
                Status = Status.Activated
            };
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}