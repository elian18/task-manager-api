using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task CreateAsync(User user);
    }
}
