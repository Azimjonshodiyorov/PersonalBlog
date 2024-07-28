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
    public sealed class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Comment?> GetByIdIncludingAllAsync(Guid id) => 
            await Entities
            .Include(comment =>comment.User)
            .Include(comment => comment.SubComments)
            .FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<Comment?> GetByIdIncludingSubcommentAsync(Guid id) =>
        await  Entities
            .Include(comment => comment.SubComments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
