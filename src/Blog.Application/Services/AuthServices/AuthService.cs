using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Application.Services.AuthServices.Interfaces;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        public Task<bool> IsRevoked(string token)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> LogIn(LoginCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task LogOut(string token)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> Refresh(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> Register(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
