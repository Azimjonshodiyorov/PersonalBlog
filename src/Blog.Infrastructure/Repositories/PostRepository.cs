using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : Repository<Post> , IPostRepository
{
    private readonly BlogDbContext _dbContext;

    public PostRepository(BlogDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Post> SerchByTitleAsync(string title)
    {
        var serchPost = await this._dbContext.Posts
            .Where(x => EF.Functions.ILike(x.Title, $"%{x.Title}%"))
            .FirstOrDefaultAsync();
        if (serchPost is null)
            throw new Exception("Not Fount this post");
        return serchPost;
    }
}