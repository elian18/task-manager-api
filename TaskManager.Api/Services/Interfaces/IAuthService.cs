using TaskManager.Api.Models.DTO;

namespace TaskManager.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
