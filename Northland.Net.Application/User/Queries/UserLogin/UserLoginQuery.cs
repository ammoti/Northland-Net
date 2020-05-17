using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.User.Queries.UserLogin
{
    public class LoginUserQuery : IRequest<UserLoginVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginVm>
    {
        private readonly INorthlandDbContext _context;
        private readonly IMapper _mapper;
        public LoginUserQueryHandler(INorthlandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserLoginVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(u => u.Email == request.Email && u.Password == request.Password).ProjectTo<UserLoginVm>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken);

            var vm = new UserLoginVm()
            {
                Id = user.Id
            };

            return vm;
        }
    }
}