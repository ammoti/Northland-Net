using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public float UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public long SupplierId { get; set; }
        public Status Status { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
        {
            private readonly INorthlandDbContext _context;
            public UpdateProductCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Products.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(Product), request.Id);

                entity.ProductName = request.ProductName;
                entity.UnitPrice = request.UnitPrice;
                entity.Package = request.Package;
                entity.ImageUrl = request.ImageUrl;
                entity.IsDiscontinued = request.IsDiscontinued;
                entity.SupplierId = request.SupplierId;
                entity.LastModified = DateTime.Now;
                entity.Status = request.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}