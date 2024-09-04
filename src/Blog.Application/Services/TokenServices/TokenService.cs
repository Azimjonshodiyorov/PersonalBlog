using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Application.DTOs.Tokens;
using Blog.Application.Services.TokenServices.Interfaces;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Application.Services.TokenServices;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSettings _jwtSettings;
    public TokenService(IConfiguration configuration , IUnitOfWork unitOfWork)
    {
        _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    public async Task<TokenResponse> GenerateTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Password", user.Password)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.LifetimeInMinutes),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _jwtSettings.Audience,
            Issuer = _jwtSettings.Issuer
        };

      
        var token = tokenHandler.CreateToken(tokenDescription);
        var accessToken = tokenHandler.WriteToken(token);
        var refreshToken = GenerateRefreshToken(user);


        user.RefreshTokens?.Add(refreshToken);
          await _unitOfWork.SaveChangesAsync();
        return new TokenResponse(
            AccessToken: accessToken,
            RefreshToken: refreshToken.Token,
            ExpiresAt: tokenDescription.Expires.Value,
            RefreshExpiresAt: refreshToken.Expires
        );
    }

    private RefreshToken GenerateRefreshToken(User user)
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString())),
            Expires = DateTime.UtcNow.AddDays(_jwtSettings.RefreshLifetimeInDays),
            CreateAt = DateTime.UtcNow,
            UserId = user.Id,
            User = user
        };

        return refreshToken;
    }
    public ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        
        return tokenHandler.ValidateToken(token, validationParameters, out _);
    }
}