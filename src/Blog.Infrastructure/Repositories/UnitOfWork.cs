using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public UnitOfWork(BlogDbContext context)
    {
        _context = context;
    }

    public BlogDbContext Context { get =>_context; } 
    private IUserRepository _users;
    public IUserRepository Users => _users ??= new UserRepository(_context);

    private IFileCvRepository _fileCvs;
    public IFileCvRepository FileCvs => _fileCvs ??= new FileCvRepository(_context);

    private IPetProjectRepository _petProjects;
    public IPetProjectRepository PetProjects => _petProjects ??= new PetProjectRepository(_context);
    private IFileMetadataRepository<IFileMetadata> _fileMetadata;

    public IFileMetadataRepository<IFileMetadata> FileMetadatas => _fileMetadata??= new FileMetadataRepository<IFileMetadata>(_context);

    private IRefreshTokenRepository _refreshTokens;
    public IRefreshTokenRepository RefreshTokens => _refreshTokens ??= new RefreshTokenRepository(_context);

    private ICertificateRepository _certificates;
    public ICertificateRepository Certificates => _certificates ??= new CertificateRepository(_context);

    private IPostRepository _posts;
    public IPostRepository Posts => _posts ??= new PostRepository(_context);

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