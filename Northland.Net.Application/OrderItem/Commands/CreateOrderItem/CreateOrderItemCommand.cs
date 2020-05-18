using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.OrderItem.Commands.CreateOrderItem
{
    public partial class CreateOrderItemCommand : IRequest<long>
    {
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, long>
    {
        private readonly INorthlandDbContext _context;
        public CreateOrderItemCommandHandler(INorthlandDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {

            var entity = new Northland.Net.Domain.OrderItem(){
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Status = Status.Activated
            };
            _context.OrderItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}