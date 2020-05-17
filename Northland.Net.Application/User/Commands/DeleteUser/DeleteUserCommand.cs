using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;

namespace Northland.Net.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly INorthlandDbContext _context;
            private readonly IIdentityService _identity;
            private readonly ICurrentUserService _currentUser;
            public DeleteUserCommandHandler(INorthlandDbContext context, IIdentityService identity, ICurrentUserService currentUser)
            {
                _context = context;
                _identity = identity;
                _currentUser = currentUser;
            }
            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(User), request.Id);

                _context.Users.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}