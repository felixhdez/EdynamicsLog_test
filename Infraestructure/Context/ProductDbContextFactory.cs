using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Context
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            var connectionString = configuration.GetConnectionString("ProductConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
