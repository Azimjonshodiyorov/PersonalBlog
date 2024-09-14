using Blog.Core.Common;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class FileMetadataRepository<T> : IFileMetadataRepository<T> where T : class, IFileMetadata
{
    private readonly BlogDbContext _dbContext;

    public FileMetadataRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(T entity)
    {
        await this._dbContext.AddAsync(entity);
    }

    public async Task<T?> FindByIdAsync(Guid id)
    {
        return await this._dbContext.Set<T>().FindAsync(id);
    }

    public async Task DeleteAsync(Guid id)
    {
        this._dbContext.Remove(id);
    }
}