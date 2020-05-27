using System.Threading.Tasks;
using Northland.Net.Application.Common.Interfaces;
using Northland.Net.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Northland.Net.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Domain.User> _userManager;
        public IdentityService(UserManager<Domain.User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new Domain.User
            {
                Email = userName,
                CreateDate = System.DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id.ToString());
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == long.Parse(userId));
            if (user != null)
                return await DeleteUserAsync(user);

            return Result.Success();
        }
        public async Task<Result> DeleteUserAsync(Domain.User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.ToApplicationResult();
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == long.Parse(userId));

            return user.Email;
        }
    }
}