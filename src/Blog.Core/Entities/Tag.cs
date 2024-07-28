using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities;

public sealed class Tag : BaseEntity
{
    public required string Name { get; set; }
    public List<Post> Posts { get; set; } = new();
}
