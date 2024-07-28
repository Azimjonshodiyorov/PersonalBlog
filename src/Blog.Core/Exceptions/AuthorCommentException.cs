using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions
{
    public class AuthorCommentException : Exception
    {
        public AuthorCommentException(Guid userId, Guid commentId)
           : base($"The user ({userId}) is not the author of the comment ({commentId})") { }
    }
}
