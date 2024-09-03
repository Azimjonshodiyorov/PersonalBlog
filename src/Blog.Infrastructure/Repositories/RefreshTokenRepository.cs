using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class RefreshTokenRepository : Repository<RefreshToken> , IRefreshTokenRepository
{
    private readonly BlogDbContext _dbContext;

    public RefreshTokenRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshToken?> GetTokenAsync(string token)
    {
        return await _dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == token);
    }

    public async Task AddTokenAsync(RefreshToken token)
    {
        await _dbContext.RefreshTokens.AddAsync(token);
    }

    public async Task RevokeTokenAsync(RefreshToken token)
    {
        token.Revoked = DateTime.UtcNow;
        _dbContext.RefreshTokens.Update(token);
    }

    public async Task<bool> IsRevokedAsync(string token)
    {
        var refreshToken = await this._dbContext.RefreshTokens
            .SingleOrDefaultAsync(x => x.Token == token);
        return refreshToken?.Revoked != null;
    }
}