using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Entities { get; }
        Task AddAsync(T entity);
        Task DeleteAsync(T  entity);
        Task UpdateAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
    }
}
