using System.Xml.Linq;

namespace Blog.Core.Entities;

public class Post : BaseEntity
{
    public  string Title { get; set; }
    public  string Description { get; set; }
    public string? Image { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}