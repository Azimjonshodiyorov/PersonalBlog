using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions
{
    public class PublicCommunityException : Exception
    {
        public PublicCommunityException() { }

        public PublicCommunityException(string message) : base(message) { }

        public PublicCommunityException(Guid communityId) : base($"The community ({communityId}) is public") { }
    }
}
