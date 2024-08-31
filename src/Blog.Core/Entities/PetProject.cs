namespace Blog.Core.Entities;

public class PetProject : BaseEntity
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public List<string> Skills { get; set; }
    public string GitHubLink { get; set; }
    public string DemoLink { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}