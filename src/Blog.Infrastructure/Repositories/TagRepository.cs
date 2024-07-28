using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        protected TagRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
