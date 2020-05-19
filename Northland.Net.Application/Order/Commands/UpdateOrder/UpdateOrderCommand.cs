using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public float TotalAmount { get; set; }
        public long UserId { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
        {
            private readonly INorthlandDbContext _context;
            public UpdateOrderCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Orders.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(Order), request.Id);

                entity.OrderDate = request.OrderDate;
                entity.OrderNumber = request.OrderNumber;
                entity.TotalAmount = request.TotalAmount;
                entity.UserId = request.UserId;

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}