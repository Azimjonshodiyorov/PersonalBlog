using Blog.Core.Entities.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IQueryable<House> Houses { get; }
        IQueryable<AddressElement> AddressElements { get; }
        IQueryable<AddressHierarchy> AddressHierarchy { get; }
        Task<string?> GetPathAsync(long objectId);
        Task<House?> GetHouseAsync(long objectId);
        Task<House?> GetHouseAsync(Guid objectId);
        Task<AddressElement?> GetAddressElementAsync(long objectId);
        Task<AddressElement?> GetAddressElementAsync(Guid objectId);

    }
}
