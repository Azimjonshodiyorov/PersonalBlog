﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;
[Table("file_cv", Schema = "blog")]
public class FileCv : BaseEntity
{
    [Column("id2")]
    public Guid Id2 { get; set; } // Faylning noyob ID si
    [Column("file_name")]
    public string FileName { get; set; } // Fayl nomi
    [Column("file_extension")]
    public string FileExtension { get; set; } // Fayl kengaytmasi (masalan, .jpg, .pdf)
    [Column("is_deleted")]
    public bool IsDeleted { get; set; } // Fayl o'chirilganmi yoki yo'qmi

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}