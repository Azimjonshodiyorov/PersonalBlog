
namespace Blog.Application.DTOs.PetProjects;

public class PetProjectDto
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public string GitHubLink { get; set; }
    public string DemoLink { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreateAt { get; set; }
    public long UserId { get; set; }
    public List<PetProjectFileDto> PetProjectFiles { get; set; }
}
