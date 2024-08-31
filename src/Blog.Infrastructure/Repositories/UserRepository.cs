using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : Repository<User> , IUserRepository
{
    protected UserRepository(BlogDbContext dbContext) : base(dbContext)
    {
    }
}