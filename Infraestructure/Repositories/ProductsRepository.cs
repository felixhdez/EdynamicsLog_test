using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly IProductDbContext _context;

        public ProductsRepository(IProductDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewProduct(Product product,
           CancellationToken cancellation)
        {
            await _context.Products.AddAsync(product, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task SaveMultipleUsers(List<Product> products,
            CancellationToken cancellation)
        {
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<List<Product>> GetAllByOrganizationId(int idOrganization,
            CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => p.IdRefOrganization == idOrganization)
                .ToListAsync(cancellationToken);
        }
    }
}
