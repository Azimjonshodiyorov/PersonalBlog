using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Core.Entities;

namespace Blog.Application.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> IsRevokedAsync(string token);
        Task LogOutAsync(string token);
        Task<TokenResponse> LogInAsync(LoginDto dto);
        Task<TokenResponse> RegisterAsync(RegistrationDto user);
        Task<TokenResponse> RefreshAsync(string refreshToken);
        
    }
}
