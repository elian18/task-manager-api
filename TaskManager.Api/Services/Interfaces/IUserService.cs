using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> CreateUser(UserRequest userRequest);
    }
}
