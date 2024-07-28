using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> IsRevoked(string token);
        Task LogOut(string token);
        Task<TokenResponse> LogIn(LoginCredentials credentials);
        Task<TokenResponse> Register(User user, string password);
        Task<TokenResponse> Refresh(string refreshToken);
    }
}
