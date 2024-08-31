namespace Blog.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get;  }
    IFileCvRepository FileCvs { get;  }
    IPetProjectRepository PetProjects { get;  }
    IRefreshTokenRepository RefreshTokens { get;  }
    ICertificateRepository Certificates { get; }
    IPostRepository Posts { get;  }

    Task<int> SaveChangesAsync();
    int Save();
}