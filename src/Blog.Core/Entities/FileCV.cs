namespace Blog.Core.Entities;

public class FileCv : BaseEntity
{
    public  string BucketName { get; init; }
    public  string FileName { get; init; }
    public  string FileType { get; init; }
    public  ulong FileSize { get; init; }
    
}