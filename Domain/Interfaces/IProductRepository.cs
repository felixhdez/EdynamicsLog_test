using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task CreateNewProduct(Product product,
           CancellationToken cancellation);
        Task SaveMultipleUsers(List<Product> products,
            CancellationToken cancellation);
        Task<List<Product>> GetAllByOrganizationId(int idOrganization,
            CancellationToken cancellationToken);
    }
}
