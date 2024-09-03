using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class FileCvRepository : Repository<FileCv> , IFileCvRepository
{
    private readonly BlogDbContext _dbContext;

    public FileCvRepository(BlogDbContext dbContext ) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }


 
}