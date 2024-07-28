using Blog.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions
{
    public class CommunityAccessException : Exception
    {
        public CommunityAccessException(Guid userId, Guid communityId)
       : base($"Access to closed community ({communityId}) is forbidden{ForUser(userId)}")
        {
        }

        public CommunityAccessException(
            Guid userId, Guid objectId,
            RestrictedCommunityAccessObjectType objectType)
            : base($"Access to closed community {objectType.ToString().ToLower()} ({objectId}) is forbidden{ForUser(userId)}")
        {
        }

        private static string ForUser(Guid id) => id != Guid.Empty ? $" for user {id}" : "";
    }
}
