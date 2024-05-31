using Application.Utils.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TenantBehavior<,>));
            services.AddAutoMapper(expression =>
            {
                expression.AddProfile(new MappingProfile(typeof(DependencyInjection).Assembly));
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
