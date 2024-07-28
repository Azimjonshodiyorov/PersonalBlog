using Blog.Core.Entities.Address;
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
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressDbContext _dbContext;

        public AddressRepository(AddressDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<House> Houses => _dbContext.Houses;

        public IQueryable<AddressElement> AddressElements => _dbContext.AddressElements;

        public IQueryable<AddressHierarchy> AddressHierarchy => _dbContext.AddressHierarchies;

        public async Task<AddressElement?> GetAddressElementAsync(long objectId) => 
            await AddressElements
            .FirstOrDefaultAsync(x => x.ObjectId == objectId);

        public async Task<AddressElement?> GetAddressElementAsync(Guid objectId) => 
          await AddressElements
            .FirstOrDefaultAsync(x=>x.ObjectGuid == objectId);

        public async Task<House?> GetHouseAsync(long objectId)
         => await Houses
            .FirstOrDefaultAsync(x=>x.Id == objectId);

        public async Task<House?> GetHouseAsync(Guid objectId)
         => await Houses
            .FirstOrDefaultAsync(x=>x.ObjectGuid== objectId);

        public async Task<string?> GetPathAsync(long objectId)
        {
            var hierarchy = await _dbContext.AddressHierarchies
                .FirstOrDefaultAsync(x=>x.ObjectId == objectId);
            return hierarchy?.Path;
        }
    }
}
