using Northland.Net.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Northland.Net.Infrastructure.Persistence;

namespace Northland.Net.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<INorthlandDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Northland"), x => x.MigrationsAssembly(typeof(INorthlandDbContext).Assembly.FullName));
        });
            services.AddScoped<INorthlandDbContext>(provider => provider.GetService<NorthlandDbContext>());
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddAuthentication().AddIdentityServerJwt();
            return services;
        }
    }
}