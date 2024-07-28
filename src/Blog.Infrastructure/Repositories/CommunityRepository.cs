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
    public sealed class CommunityRepository : Repository<Community>, ICommunityRepository
    {
        public CommunityRepository(BlogDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Subscription> Subscriptions =>_dbContext.Subscriptions;

        public IQueryable<CommunityAdmin> Admins => _dbContext.CommunityAdmins;

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Community?> GetByIdIncludingAllMembersAsync(Guid id) => 
            await Entities
            .Include(community => community.Administrators)
            .Include(community => community.Subscribers)
            .FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<Community?> GetByIdIncludingRequestsAndAdminAsync(Guid id) => 
             await Entities
            .Include(community => community.Administrators)
            .Include(community => community.Requests)!
            .ThenInclude(request => request.User)
            .FirstOrDefaultAsync(community => community.Id == id);

        public async Task<Community?> GetByIdIncludingRequestsAndSubscribersAsync(Guid id) =>
             await Entities
            .Include(community => community.Subscribers)
            .Include(community => community.Requests)
            .FirstOrDefaultAsync(community => community.Id == id);

        public async Task<Community?> GetByIdIncludingRequestsAsync(Guid id) =>
            await  Entities
            .Include (community => community.Requests)
            .FirstOrDefaultAsync (community => community.Id == id);

        public async Task<Community?> GetByIdIncludingSubscribersAsync(Guid id) =>
           await Entities
            .Include(community => community.Subscribers)
            .FirstOrDefaultAsync(community => community.Id == id);

    }
}
