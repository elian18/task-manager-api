using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
    }
}
