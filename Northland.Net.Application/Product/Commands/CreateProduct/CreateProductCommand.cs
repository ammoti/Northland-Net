using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.Product.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<long>
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public float UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public long SupplierId { get; set; }

    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly INorthlandDbContext _context;
        public CreateProductCommandHandler(INorthlandDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var entity = new Northland.Net.Domain.Product()
            {
                CreateDate = DateTime.Now,
                ProductName = request.ProductName,
                ImageUrl = request.ImageUrl,
                UnitPrice = request.UnitPrice,
                Package = request.Package,
                IsDiscontinued = request.IsDiscontinued,
                SupplierId = request.SupplierId,
                Status = Status.Activated
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}