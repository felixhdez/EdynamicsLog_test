using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IProductDbContext : IDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
