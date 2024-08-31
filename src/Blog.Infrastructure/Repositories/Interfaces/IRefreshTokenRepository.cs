using Blog.Core.Entities;

namespace Blog.Infrastructure.Repositories.Interfaces;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetTokenAsync(string token);
    Task AddTokenAsync(RefreshToken token);
    Task RevokeTokenAsync(RefreshToken token);
}