using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IOrganizationDbContext _context;

        public UsersRepository(IOrganizationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPassword(
            string email, string password, CancellationToken cancellation)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Organization)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password,
                    cancellation);
        }

        public async Task CreateUser(User user, CancellationToken cancellation) 
        { 
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task SaveMultipleUsers(List<User> users, CancellationToken cancellation)
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
