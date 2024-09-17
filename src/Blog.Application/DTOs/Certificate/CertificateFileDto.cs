namespace Blog.Application.DTOs.Certificates;

public class CertificateFileDto
{
    public Guid Id2 { get; set; } 
    public string FileName { get; set; }
    public DateTime CreateAt { get; set; }
    public string FileExtension { get; set; }
    public bool IsDeleted { get; set; }
}