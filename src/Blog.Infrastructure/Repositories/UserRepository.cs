using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private  readonly BlogDbContext _dbContext;

    public UserRepository(BlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
    {
        var user = await this._dbContext.Users
            .Where(x=>x.Email == email && x.Password == password)
            .FirstOrDefaultAsync();
        if(user == null)
        {
            throw new Exception("Email or Password Invalid!!");
        }
        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new Exception($"email is null  User repo ");
        }
        return user;
    }

   
}