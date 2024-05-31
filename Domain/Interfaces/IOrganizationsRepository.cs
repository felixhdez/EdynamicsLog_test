using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrganizationsRepository
    {
        Task<Organization> GetById(int id);
        Task CreateNewOrganization(Organization organization,
            CancellationToken cancellation);
        Task<Organization> GetBySlug(string tenant,
            CancellationToken cancellation);
    }
}
