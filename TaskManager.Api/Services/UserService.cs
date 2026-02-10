using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TaskManager.Api.Exceptions;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Repositories.Interfaces;
using TaskManager.Api.Services.Interfaces;
using TaskManager.Api.Types;

namespace TaskManager.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            return await userRepository.GetAllUsers();
        }
        public async Task<UserResponse> GetUserByEmail(string email)
        {
            User user = await userRepository.GetUserByEmail(email);
            if (user == null) throw new ArgumentException(Errors.UserNotFound.ToString());
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email
            };
        }
        public async Task<UserResponse> GetUserById(Guid id)
        {
            User user = await userRepository.GetUserById(id);
            if (user == null) throw new ArgumentException(Errors.UserNotFound.ToString());
            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email
            };
        }
        public async Task<IActionResult> CreateUser(UserRequest userRequest)
        {
            User user = await userRepository.GetUserByEmail(userRequest.Email);
            if (user != null) throw new ArgumentException(Errors.EmailAlreadyExists.ToString());
            user = new User();
            user.Id = Guid.NewGuid();
            user.Email = userRequest.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password);
            user.CreatedAt = DateTime.UtcNow;
            await userRepository.Add(user);
            return await Task.FromResult(new OkObjectResult(new { Status = TypeStatus.SUCCESS.ToString() }));
        }
    }
}
