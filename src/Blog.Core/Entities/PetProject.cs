using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;
[Table("blog" , Schema ="pet_project")]
public class PetProject : BaseEntity
{
    [Column("project_name")]
    public string ProjectName { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [NotMapped]
    public List<string> Skills { get; set; }

    [Column("github_link")]
    public string GitHubLink { get; set; }

    [Column("demo_link")]
    public string DemoLink { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}