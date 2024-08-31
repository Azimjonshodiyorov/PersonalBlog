namespace Blog.Core.Entities;

public class FileCv : BaseEntity
{
    public  string BucketName { get; set; }
    public  string FileName { get; set; }
    public  string FileType { get; set; }
    public  ulong FileSize { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}