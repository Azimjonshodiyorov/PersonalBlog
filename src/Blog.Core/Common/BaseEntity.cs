using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Common;

public class BaseEntity
{
    [Column("id")]
    [Key]
    public long Id { get; set; }

    [Column("created_at")] 
    public DateTime CreateAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime? UpdateAt { get; set; } 
}