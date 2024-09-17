namespace Blog.Application.DTOs.Certificates;

public class CreateCertificateDto
{
    public string CertificateLink { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
}