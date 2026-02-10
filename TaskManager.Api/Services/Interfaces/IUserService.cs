using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserByEmail(string email);
        Task<UserResponse> GetUserById(Guid id);
        Task<IActionResult> CreateUser(UserRequest userRequest);
    }
}
