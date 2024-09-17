namespace Blog.Application.DTOs.Certificates;

public class UpdateCertificateDto
{
    public string CertificateLink { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
}