using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
        {
            private readonly INorthlandDbContext _context;
            public DeleteSupplierCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Suppliers.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(User), request.Id);

                _context.Suppliers.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}