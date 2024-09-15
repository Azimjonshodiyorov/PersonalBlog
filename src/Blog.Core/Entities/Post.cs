using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Blog.Core.Common;

namespace Blog.Core.Entities;
[Table("post",Schema ="blog")]
public class Post : BaseEntity
{
    [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string Description { get; set; }
    [Column("is_delete")]
    public bool IsDelete { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    [NotMapped]
    public ICollection<PostFile> PostFiles { get; set; }
}