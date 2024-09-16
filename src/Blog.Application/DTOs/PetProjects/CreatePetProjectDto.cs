
namespace Blog.Application.DTOs.PetProjects;

public class CreatePetProjectDto
{
    public string ProjectName { get; set; }

    public string Description { get; set; }

    public string GitHubLink { get; set; }

    public string DemoLink { get; set; }

    public long UserId { get; set; }
}
