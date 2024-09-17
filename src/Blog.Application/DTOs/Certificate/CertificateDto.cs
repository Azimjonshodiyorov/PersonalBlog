namespace Blog.Application.DTOs.Certificates;

public class CertificateDto
{
    public string CertificateLink { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public long UserId { get; set; }
    public long Id { get; set; }
    public List<CertificateFileDto>  CertificateFiles { get; set; }
}