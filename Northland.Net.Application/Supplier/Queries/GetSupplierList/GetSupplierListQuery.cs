using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.Supplier.Queries.GetSupplierList
{
    public class GetSupplierListQuery : IRequest<SupplierListVm>
    {

    }
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, SupplierListVm>
    {
        private readonly INorthlandDbContext _context;
        private readonly IMapper _mapper;

        public GetSupplierListQueryHandler(INorthlandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SupplierListVm> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _context.Suppliers.ProjectTo<SupplierListDto>(_mapper.ConfigurationProvider).OrderBy(e => e.CompanyName).ToListAsync(cancellationToken);

            var vm = new SupplierListVm()
            {
                Suppliers = suppliers
            };

            return vm;
        }
    }
}