namespace Blog.Application.DTOs.Files;

public class UpdateFileCvDto
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public bool IsDeleted { get; set; }
}