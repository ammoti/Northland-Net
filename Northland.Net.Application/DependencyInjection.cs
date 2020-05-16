using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Northland.Net.Application.Common.Behaviours;

namespace Northland.Net.Application
{
    public static class DependencyInjecton
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}