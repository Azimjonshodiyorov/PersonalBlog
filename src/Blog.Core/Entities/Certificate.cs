using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;
[Table("certificate" , Schema = "blog")]
public class Certificate : BaseEntity
{
    [Column("image_base64")]
    public string ImageBase64 { get; set; }

    [Column("certificate_link")]
    public string CertificateLink { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}