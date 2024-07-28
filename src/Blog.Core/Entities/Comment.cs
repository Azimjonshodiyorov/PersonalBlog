namespace Blog.Core.Entities;

public sealed class Comment : BaseEntity
{
    public required string Content { get; set; }
    public DateTime? DeleteAt { get; set; }
    public List<Comment> SubComments { get; set; } = new();

    public User User { get; set; }
    public required Guid UserId { get; set; }

    public Comment Parent { get; set; }
    public Guid? ParentId { get; set; }

    public required Guid PostId { get; set; }
}