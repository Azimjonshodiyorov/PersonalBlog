using System.Security.Claims;
using Blog.Application.DTOs.Tokens;
using Blog.Core.Entities;

namespace Blog.Application.Services.TokenServices.Interfaces;

public interface ITokenService
{
    Task<TokenResponse> GenerateTokenAsync(User user);
    ClaimsPrincipal ValidateToken(string token);
}