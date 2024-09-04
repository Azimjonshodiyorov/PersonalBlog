using Blog.Infrastructure.AppDbContext;

namespace Blog.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    BlogDbContext Context { get; }
    IUserRepository Users { get;  }
    IFileCvRepository FileCvs { get;  }
    IPetProjectRepository PetProjects { get;  }
    IRefreshTokenRepository RefreshTokens { get;  }
    ICertificateRepository Certificates { get; }
    IPostRepository Posts { get;  }

    Task<int> SaveChangesAsync();
    int Save();
}