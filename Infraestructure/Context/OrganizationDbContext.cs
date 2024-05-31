using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class OrganizationDbContext : DbContext, IOrganizationDbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
