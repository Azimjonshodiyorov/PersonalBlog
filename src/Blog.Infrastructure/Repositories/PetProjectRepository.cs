using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class PetProjectRepository : Repository<PetProject> , IPetProjectRepository
{
    public PetProjectRepository(BlogDbContext dbContext) 
        : base(dbContext)
    {
    }
}