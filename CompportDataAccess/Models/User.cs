using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnet.DataAccess.Models;

namespace CompportDataAccess.Models;

public enum UserRole
{
    Admin,
    User,
    Customer,
    CustomerSupport,
    Technician
}

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get; set;
    }

    [Required(ErrorMessage = "name is required.")]
    [MaxLength(30, ErrorMessage = "name cannot exceed 30 characters.")]
    public string Name { get; set; } = String.Empty;

    [Required(ErrorMessage = "surname is required.")]
    [MaxLength(30, ErrorMessage = "surname cannot exceed 30 characters.")]
    public string Surname { get; set; } = String.Empty;

    [Required(ErrorMessage = "email is required.")]
    [MaxLength(30, ErrorMessage = "email cannot exceed 30 characters.")]
    // checked in business layer
    //[EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "phone is required.")]
    [MaxLength(13, ErrorMessage = "phone cannot exceed 11 characters.")]
    // checked in business layer
    //[Phone(ErrorMessage = "Invalid phone number.")]
    public string Phone { get; set; } = String.Empty;

    [Required(ErrorMessage = "password hash is required.")]
    [MaxLength(255, ErrorMessage = "password hash cannot exceed 100 characters.")]
    public string PasswordHash { get; set; } = String.Empty;

    [Required(ErrorMessage = "user role is required.")]
    public UserRole Role
    {
        get; set;
    }

    //public Address Address { get; set; } = null!;

    public ICollection<Device> Devices { get; set; } = new List<Device>();

    public bool IsActive { get; set; } = true;
}
