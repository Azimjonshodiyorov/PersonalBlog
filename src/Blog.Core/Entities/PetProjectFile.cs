
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;
[Table("blog",Schema ="pet_project_file")]
public class PetProjectFile 
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
    [Column("uploaded_at")]
    public DateTime UploadedAt { get; set; } // Fayl yuklangan vaqti
    [Column("delete_at")]
    public DateTime? DeletedAt { get; set; } // Fayl o'chirilgan vaqti
    [NotMapped]
    public PetProject petProject { get; set; }

}
