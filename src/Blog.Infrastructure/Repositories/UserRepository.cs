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
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetByIdIncludingCommunities(Guid id)
        {
           return await  Entities.Include(x=>x.Subscriptions)
                .Include(x=>x.AdministeredCommunities)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
