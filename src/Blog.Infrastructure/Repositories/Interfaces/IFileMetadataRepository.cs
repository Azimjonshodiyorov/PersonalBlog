using Blog.Core.Common;

namespace Blog.Infrastructure.Repositories.Interfaces;

public interface IFileMetadataRepository<T> where T : class, IFileMetadata
{
    Task AddAsync(T entity);
    Task<T?> FindByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}