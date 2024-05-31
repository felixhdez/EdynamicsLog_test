using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class OrganizationsRepository : IOrganizationsRepository
    {
        private readonly IOrganizationDbContext _context;

        public OrganizationsRepository(IOrganizationDbContext context)
        {
            _context = context;
        }

        public async Task<Organization> GetById(int id)
        {
            return await _context.Organizations
                .FindAsync(id);
        }

        public async Task CreateNewOrganization(Organization organization,
            CancellationToken cancellation)
        {
            await _context.Organizations.AddAsync(organization, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<Organization> GetBySlug(string tenant,
            CancellationToken cancellation)
        {
            return await _context.Organizations
                .FirstOrDefaultAsync(o => o.SlugTenant == tenant,
                    cancellation);
        }
    }
}
