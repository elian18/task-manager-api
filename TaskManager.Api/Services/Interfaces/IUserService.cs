using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);
    }
}
