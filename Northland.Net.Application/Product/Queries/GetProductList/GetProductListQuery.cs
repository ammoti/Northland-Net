using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.Product.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {

    }
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly INorthlandDbContext _context;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(INorthlandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ProjectTo<ProductListDto>(_mapper.ConfigurationProvider).OrderBy(e => e.ProductName).ToListAsync(cancellationToken);

            var vm = new ProductListVm()
            {
                Products = products
            };

            return vm;
        }
    }
}