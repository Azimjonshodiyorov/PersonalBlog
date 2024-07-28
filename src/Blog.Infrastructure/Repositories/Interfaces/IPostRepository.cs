using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task AddFavoritePostAsync(FavoritePost favoritePost);
        Task<Post?> GetByIdIncludingAllAsync(Guid id);
        Task<Post?> GetByIdIncludingLikesAsync(Guid id);
        Task<Post?> GetByIdIncludingCommentsAsync(Guid id);
        Task<Post?> GetByIdIncludingFavoriteByUsersAsync(Guid id);
    }
}
