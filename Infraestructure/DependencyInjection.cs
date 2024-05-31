using Domain.Interfaces;
using Infraestructure.Context;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Configure the database connections
            var connectionStringDefault = configuration.GetConnectionString("DefaultConnection");
            var connectionStringProduct = configuration.GetConnectionString("ProductConnection");

            services.AddDbContext<OrganizationDbContext>(options =>
                options.UseSqlServer(connectionStringDefault));

            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(connectionStringProduct));

            services.AddScoped<IOrganizationDbContext>(provider => provider.GetService<OrganizationDbContext>());
            services.AddScoped<IProductDbContext>(provider => provider.GetService<ProductDbContext>());

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
            services.AddScoped<IProductRepository, ProductsRepository>();

            return services;
        }
    }
}
