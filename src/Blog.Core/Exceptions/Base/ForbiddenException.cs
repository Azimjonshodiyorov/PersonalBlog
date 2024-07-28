using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions.Base
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message) { }

        public ForbiddenException(Guid userId) : base($"Access is forbidden for user ({userId})") { }
    }
}
