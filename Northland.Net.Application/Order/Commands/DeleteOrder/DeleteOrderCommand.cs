using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
        {
            private readonly INorthlandDbContext _context;
            public DeleteOrderCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Orders.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(User), request.Id);

                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}