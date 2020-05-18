using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.OrderItem.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest
    {
        public int Id { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
        {
            private readonly INorthlandDbContext _context;
            public UpdateOrderItemCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.OrderItems.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(OrderItem), request.Id);

                entity.UnitPrice = request.UnitPrice;
                entity.Quantity = request.Quantity;
                entity.OrderId = request.OrderId;
                entity.ProductId = request.ProductId;

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}