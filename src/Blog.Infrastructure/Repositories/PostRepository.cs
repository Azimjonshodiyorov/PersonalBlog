using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : Repository<Post> , IPostRepository
{
    protected PostRepository(BlogDbContext dbContext) 
        : base(dbContext)
    {
    }
}