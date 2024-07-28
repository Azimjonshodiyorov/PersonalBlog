using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Interfaces
{
    public interface ICommunityRepository : IRepository<Community>
    {
        IQueryable<Subscription> Subscriptions { get; }
        IQueryable<CommunityAdmin> Admins { get; }  

        Task AddSubscriptionAsync(Subscription subscription);

        Task<Community?> GetByIdIncludingAllMembersAsync(Guid id);
        Task<Community?> GetByIdIncludingRequestsAsync(Guid id);
        Task<Community?> GetByIdIncludingSubscribersAsync(Guid id);
        Task<Community?> GetByIdIncludingRequestsAndAdminAsync(Guid id);
        Task<Community?> GetByIdIncludingRequestsAndSubscribersAsync(Guid id);

    }
}
