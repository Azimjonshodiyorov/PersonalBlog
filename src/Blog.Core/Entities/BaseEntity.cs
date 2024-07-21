namespace Blog.Core.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}