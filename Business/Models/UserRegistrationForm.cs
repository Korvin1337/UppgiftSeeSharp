using System.ComponentModel.DataAnnotations;

namespace Busniess.Models;

public class UserRegistrationForm
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;
    [Required]
    public string PostalNumber { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
}
