using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Common;

namespace Blog.Core.Entities;
[Table("post_file",Schema ="blog")]
public class PostFile : BaseEntity , IFileMetadata
{
    [Column("owner_id")]
    public long OwnerId { get; set; }
    [Column("id2")]
    public Guid Id2 { get; set; } // Faylning noyob ID si
    [Column("file_name")]
    public string FileName { get; set; } // Fayl nomi
    [Column("file_extension")]
    public string FileExtension { get; set; } // Fayl kengaytmasi (masalan, .jpg, .pdf)
    [Column("is_deleted")]
    public bool IsDeleted { get; set; } // Fayl o'chirilganmi yoki yo'qmi
    [NotMapped]
    public Post Post { get; set; }
}
