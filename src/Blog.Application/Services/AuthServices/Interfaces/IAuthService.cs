using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Core.Entities;

namespace Blog.Application.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> IsRevoked(string token);
        Task LogOut(string token);
        Task<TokenResponse> LogIn(LoginDto dto);
        Task<TokenResponse> Register(User user, string password);
        Task<TokenResponse> Refresh(string refreshToken);
    }
}
