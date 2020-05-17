using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Domain;

namespace Northland.Net.Application.User.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly INorthlandDbContext _context;
        public CreateUserCommandHandler(INorthlandDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var entity = new Northland.Net.Domain.User(){
                Email = request.Email,
                ImageUrl = "Default.png",
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                Roles = Roles.User,
                Status = Status.Activated
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}