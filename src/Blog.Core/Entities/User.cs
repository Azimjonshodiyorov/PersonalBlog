using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Enum;

namespace Blog.Core.Entities;

[Table("blog" , Schema ="user")]
public  class User : BaseEntity
{
    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    [Column("gender")]
    public Gender Gender { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [NotMapped]
    public IQueryable<Post>? Posts { get; set; }

    [NotMapped]
    public IQueryable<FileCv>? FileCvs { get; set; }

    [NotMapped]
    public IQueryable<Certificate>? Certificates { get; set; }

    [NotMapped]
    public IQueryable<PetProject>? PetProjects { get; set; }

    [NotMapped]
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}