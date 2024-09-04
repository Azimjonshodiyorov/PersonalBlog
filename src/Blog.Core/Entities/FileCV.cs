using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;
[Table("file_cv", Schema = "blog")]
public class FileCv : BaseEntity
{
    [Column("bucket_name")]
    public string BucketName { get; set; }

    [Column("file_name")]
    public string FileName { get; set; }

    [Column("file_type")]
    public string FileType { get; set; }

    [Column("file_size")]
    public ulong FileSize { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}