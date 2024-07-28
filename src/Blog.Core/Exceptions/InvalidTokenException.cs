using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException() : base("Invalid token") { }
    }
}
