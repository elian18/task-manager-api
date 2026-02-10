using System.Security.Cryptography;
using System.Text;
using TaskManager.Api.Models;
using TaskManager.Api.Models.DTO;
using TaskManager.Api.Repositories.Interfaces;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            await _repository.CreateAsync(user);
            return user;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
