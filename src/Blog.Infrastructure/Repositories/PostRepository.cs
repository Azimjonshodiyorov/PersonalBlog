using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public sealed class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddFavoritePostAsync(FavoritePost favoritePost)
        {
            await _dbContext.AddAsync(favoritePost);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<Post?> GetByIdIncludingAllAsync(Guid id) =>
             await Entities.Include(post => post.User)
                .Include(post=>post.Likes)
                .Include(post=>post.Community)
                .Include(post=>post.Tags)
                .Include(post=> post.Comments)
                .ThenInclude(commet => commet.User)
                .FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<Post?> GetByIdIncludingCommentsAsync(Guid id) =>
            await Entities
            .Include(post => post.Comments)
            .FirstOrDefaultAsync(post => post.Id == id);

        public async Task<Post?> GetByIdIncludingFavoriteByUsersAsync(Guid id) =>
            await Entities.Include(post => post.FavoriteByUsers)
            .FirstOrDefaultAsync(post => post.Id == id);
        public async Task<Post?> GetByIdIncludingLikesAsync(Guid id) => 
            await Entities.Include(post => post.Likes)
            .FirstOrDefaultAsync (post => post.Id == id);
    }
}
