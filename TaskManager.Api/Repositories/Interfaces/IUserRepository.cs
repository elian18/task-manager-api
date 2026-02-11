using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<UserResponse>> GetAllUsers();
        Task<User?> GetUserById(Guid id);
        Task<User?> GetUserByEmail(string email);
    }
}
