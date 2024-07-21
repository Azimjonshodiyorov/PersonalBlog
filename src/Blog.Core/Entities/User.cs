namespace Blog.Core.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public ICollection<Post> Posts { get; set; }
}