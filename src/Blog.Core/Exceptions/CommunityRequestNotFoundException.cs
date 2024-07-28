using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions
{
    public class CommunityRequestNotFoundException : Exception
    {
        public CommunityRequestNotFoundException() { }

        public CommunityRequestNotFoundException(string message) : base(message) { }

        public CommunityRequestNotFoundException(Guid userId, Guid communityId)
            : base($"The user's ({userId}) request to join the community ({communityId}) was not found")
        {
        }
    }
}
