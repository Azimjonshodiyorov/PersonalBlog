using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Common;

namespace Blog.Core.Entities;
[Table("certificate" , Schema = "blog")]
public class Certificate : BaseEntity
{

    [Column("certificate_link")]
    public string CertificateLink { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    [NotMapped]
    public ICollection<CertificateFile>  CertificateFiles { get; set; }

}