using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Application.Services.AuthServices.Interfaces;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(IUserRepository userRepository , IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<bool> IsRevokedAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task LogOutAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> LogInAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> RegisterAsync(RegistrationDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> RefreshAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
