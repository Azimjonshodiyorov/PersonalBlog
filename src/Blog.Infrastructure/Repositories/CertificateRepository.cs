using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class CertificateRepository : Repository<Certificate> , ICertificateRepository
{
    protected CertificateRepository(BlogDbContext dbContext) 
        : base(dbContext)
    {
    }
}