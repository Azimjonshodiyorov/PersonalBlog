using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Common;

namespace Blog.Core.Entities;
[Table("skill" , Schema = "blog")]
public class Skill : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
}