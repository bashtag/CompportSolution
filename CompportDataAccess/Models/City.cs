using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet.DataAccess.Models
{
	public class City
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(20, ErrorMessage = "cityName cannot exceed 20 characters.")]
		[Required(ErrorMessage = "cityName is required.")]
		public string? CityName { get; set; } = string.Empty;

		public ICollection<District> Districts { get; } = new List<District>();
	}
}