namespace Blog.Core.Entities;

public class FileCv : BaseEntity
{
    public  string BucketName { get; init; }
    public  string FileName { get; init; }
    public  string FileType { get; init; }
    public  ulong FileSize { get; init; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}