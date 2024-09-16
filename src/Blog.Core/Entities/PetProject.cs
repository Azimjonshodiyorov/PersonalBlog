using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Common;

namespace Blog.Core.Entities;
[Table("pet_project" , Schema ="blog")]
public class PetProject : BaseEntity
{
    [Column("project_name")]
    public string ProjectName { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("is_delete")]
    public bool IsDelete { get; set; }

    [Column("github_link")]
    public string GitHubLink { get; set; }

    [Column("demo_link")]
    public string DemoLink { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    [NotMapped]
    public ICollection<PetProjectFile>  PetProjectFiles { get; set; }

}