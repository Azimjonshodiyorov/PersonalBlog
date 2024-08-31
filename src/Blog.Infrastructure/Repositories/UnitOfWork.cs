using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogDbContext _context;

    public UnitOfWork(BlogDbContext context)
    {
        _context = context;
    }

    public IUserRepository Users { get; }
    public IFileCvRepository FileCvs { get; }
    public IPetProjectRepository PetProjects { get; }
    public IRefreshTokenRepository RefreshTokens { get; }
    public ICertificateRepository Certificates { get; }
    public IPostRepository Posts { get; }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}