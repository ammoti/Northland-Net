using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Exceptions;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Roles Roles { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly INorthlandDbContext _context;
            public UpdateUserCommandHandler(INorthlandDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users.FindAsync(request.Id);
                if (entity == null) throw new NotFoundException(nameof(User), request.Id);

                entity.Name = request.Name;
                entity.Surname = request.Surname;
                entity.Email = request.Email;
                entity.Password = request.Password;
                entity.Roles = request.Roles;
                entity.ImageUrl = request.ImageUrl;

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}