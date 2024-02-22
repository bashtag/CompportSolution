using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet.DataAccess.Models
{
	public class District
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(30, ErrorMessage ="districtName cannot exceed 30 characters.")]
		[Required(ErrorMessage = "districtName is required.")]
		public string ?DistrictName { get; set; } = string.Empty;

		[Required(ErrorMessage = "city is required.")]
		public City City { get; set; } = null!;
	}
}