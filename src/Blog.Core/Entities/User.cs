using Blog.Core.Enum;

namespace Blog.Core.Entities;

public sealed class User : BaseEntity
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public  Gender Gender { get; set; }
    public  string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public IQueryable<Post>? Posts { get; set; }
    public IQueryable<FileCv>? FileCvs { get; set; }
    public IQueryable<Certificate>? Certificates { get; set; }
    public IQueryable<PetProject>? PetProjects { get; set; }
    
    public List<RefreshToken>? RefreshTokens { get; set; }
}