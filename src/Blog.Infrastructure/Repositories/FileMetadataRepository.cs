using Blog.Core.Common;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class FileMetadataRepository<T> : IFileMetadataRepository<T> where T : class, IFileMetadata
{
    public async Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<T> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}