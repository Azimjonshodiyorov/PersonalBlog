using Blog.Core.Enum;

namespace Blog.Application.DTOs.User;

public class UpdateUserDto
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public  Gender Gender { get; set; }
    public  string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
}