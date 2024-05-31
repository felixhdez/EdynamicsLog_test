using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IOrganizationDbContext : IDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<User> Users { get; set; }
    }
}
