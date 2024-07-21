namespace Blog.Core.Entities;

public class Post : BaseEntity
{
    public string Content { get; set; }
    public string Name { get; set; }
    public string ImageBase64 { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}