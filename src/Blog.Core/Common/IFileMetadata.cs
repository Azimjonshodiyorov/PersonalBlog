namespace Blog.Core.Common;

public interface IFileMetadata
{
    Guid Id2 { get; set; }
    string FileName { get; set; }
    string FileExtension { get; set; }
    bool IsDeleted { get; set; }
    long OwnerId { get; set; }
}