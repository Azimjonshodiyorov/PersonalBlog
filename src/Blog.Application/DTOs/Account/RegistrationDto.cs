using System.ComponentModel.DataAnnotations;
using Blog.Core.Enum;

namespace Blog.Application.DTOs.Account;

public class RegistrationDto
{
    
    [Required(ErrorMessage = "First Name is required")]
    public  string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public  string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public  Gender Gender { get; set; }
    public  string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
}