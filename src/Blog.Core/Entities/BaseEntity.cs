using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;

public class BaseEntity
{
    [Column("id")]
    [Key]
    public long Id { get; set; }

    [Column("created_at")]
    public DateTime CreateAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdateAt { get; set; }
}