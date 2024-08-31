namespace Blog.Core.Entities;

public class Certificate : BaseEntity
{
    public string ImageBase64 { get; set; }
    public string CertificateLink { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}