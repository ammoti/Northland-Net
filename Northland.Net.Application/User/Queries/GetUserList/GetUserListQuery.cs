using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.User.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
      
    }
      public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
        {
            private readonly INorthlandDbContext _context;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(INorthlandDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.ProjectTo<UserListDto>(_mapper.ConfigurationProvider).OrderBy(e => e.Name).ToListAsync(cancellationToken);

                var vm = new UserListVm()
                {
                    Users = users
                };

                return vm;
            }
        }
}