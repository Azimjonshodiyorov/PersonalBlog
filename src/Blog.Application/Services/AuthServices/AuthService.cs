using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Application.Services.AuthServices.Interfaces;
using Blog.Core.Entities;
using AutoMapper;
using Blog.Application.Services.TokenServices.Interfaces;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthService(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task<bool> IsRevokedAsync(string token)
        {
            return await _unitOfWork.RefreshTokens.IsRevokedAsync(token);
        }

        public async Task LogOutAsync(string token)
        {
            var refreshToken = await _unitOfWork.RefreshTokens.GetTokenAsync(token);
            if (refreshToken != null)
            {
                refreshToken.Revoked = DateTime.UtcNow;
                await _unitOfWork.RefreshTokens.UpdateAsync(refreshToken);
                await _unitOfWork.SaveChangesAsync(); 
            }
        }

        public async Task<TokenResponse> LogInAsync(LoginDto dto)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }

            return await _tokenService.GenerateTokenAsync(user);
        }

        public async Task<TokenResponse> RegisterAsync(RegistrationDto user)
        {
            try
            {
                var existingUser = await this._unitOfWork.Users
                    .Entities
                    .Where(x=>x.Email == user.Email).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    throw new Exception("User already exists.");
                }
        
                var result = this._mapper.Map<User>(user);
                await _unitOfWork.Users.AddAsync(result);
                await this._unitOfWork.SaveChangesAsync();
                return await this._tokenService.GenerateTokenAsync(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed.", ex);
            }
        }

        public async Task<TokenResponse> RefreshAsync(string refreshToken)
        {
            var refresh = await this._unitOfWork.RefreshTokens.GetTokenAsync(refreshToken);
            if (refresh == null || await _unitOfWork.RefreshTokens.IsRevokedAsync(refreshToken) || !refresh.IsActive)
            {
                throw new Exception("Invalid or revoked refresh token.");
            }

            var user = await this._unitOfWork.Users.GetByIdAsync(refresh.UserId);
            refresh.Revoked = DateTime.UtcNow;
            await _unitOfWork.RefreshTokens.UpdateAsync(refresh);
            await _unitOfWork.SaveChangesAsync();
            if (user != null)
                throw new Exception("user null authservice");
            return await _tokenService.GenerateTokenAsync(user);
        }
    }
}
