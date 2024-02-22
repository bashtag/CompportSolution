using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.DataAccess.Models
{
	public class Address
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "name is required.")]
		[MaxLength(30, ErrorMessage = "name cannot exceed 30 characters.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "surname is required.")]
		public City City { get; set; } = null!;

		[Required(ErrorMessage = "district is required.")]
		public District District { get; set; } = null!;

		[Required(ErrorMessage = "hood is required.")]
		[MaxLength(50, ErrorMessage = "hood cannot exceed 50 characters.")]
		public string Hood { get; set; } = string.Empty;

		[Required(ErrorMessage = "zipCode is required.")]
		public int ZipCode { get; set; }

		[Required(ErrorMessage = "description is required.")]
		[MaxLength(300, ErrorMessage = "description cannot exceed 300 characters.")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		[MaxLength(25, ErrorMessage = "email cannot exceed 25 characters.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "phone is required.")]
		[Phone(ErrorMessage = "Invalid phone number.")]
		[MaxLength(13, ErrorMessage = "phone cannot exceed 11 characters.")]
		public string Phone { get; set; } = string.Empty;

		public bool IsActive { get; set; } = true;
	}
}