using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.Order.Commands.CreateOrder
{
    public partial class CreateOrderCommand : IRequest<long>
    {
      public DateTime OrderDate { get; set; }   
      public string OrderNumber { get; set; }
      public float TotalAmount { get; set; }
      public long UserId { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly INorthlandDbContext _context;
        public CreateOrderCommandHandler(INorthlandDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var entity = new Northland.Net.Domain.Order(){
                CreateDate = DateTime.Now,
                OrderDate = request.OrderDate,
                OrderNumber = request.OrderNumber,
                TotalAmount = request.TotalAmount,
                UserId = request.UserId,
                Status = Status.Activated
            };
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}