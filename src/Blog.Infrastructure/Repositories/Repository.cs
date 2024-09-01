using Blog.Core.Entities;
using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BlogDbContext _dbContext;

        protected Repository(BlogDbContext dbContext) =>
                          _dbContext = dbContext;
        

        public IQueryable<T> Entities => this._dbContext.Set<T>();

        public async  Task AddAsync(T entity)
        {
            _dbContext.Add(entity);
        }

        public async  Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);   
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async  Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
