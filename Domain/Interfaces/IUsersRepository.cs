using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserByEmailAndPassword(
            string email, string password,
            CancellationToken cancellation);
        Task CreateUser(User user,
            CancellationToken cancellation);
        Task SaveMultipleUsers(List<User> users,
            CancellationToken cancellation);
    }
}
