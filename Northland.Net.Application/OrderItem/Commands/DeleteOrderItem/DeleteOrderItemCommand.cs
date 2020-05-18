using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.OrderItem.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand>
        {
            private readonly INorthlandDbContext _context;
            public DeleteOrderItemCommandHandler(INorthlandDbContext context, IIdentityService identity, ICurrentUserService currentUser)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.OrderItems.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(User), request.Id);

                _context.OrderItems.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}