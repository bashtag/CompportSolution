using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompportDataAccess.Models
{
	public class ComputerModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		[Required(ErrorMessage = "modelNumber is required.")]
		[MaxLength(30, ErrorMessage ="modelNumber cannot exceed 30 characters.")]
		public string ModelNumber { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "brandName is required.")]
		[MaxLength(30, ErrorMessage ="brandName cannot exceed 30 characters.")]
		public string BrandName { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "modelName is required.")]
		[MaxLength(30, ErrorMessage ="modelName cannot exceed 30 characters.")]
		public string ModelName { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "releaseDate is required.")]
		public DateTime ReleaseDate { get; set; }
		
		public string Description { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "processorDescription is required.")]
		[MaxLength(255, ErrorMessage ="processorDescription cannot exceed 255 characters.")]
		public string ProcessorDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "ramDescription is required.")]
		[MaxLength(255, ErrorMessage ="ramDescription cannot exceed 255 characters.")]
		public string RamDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "storageDescription is required.")]
		[MaxLength(255, ErrorMessage ="storageDescription cannot exceed 255 characters.")]
		public string StorageDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "osDescription is required.")]
		[MaxLength(255, ErrorMessage ="osDescription cannot exceed 255 characters.")]
		public string OperatingSystemDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "graphicsCardDescription is required.")]
		[MaxLength(255, ErrorMessage ="graphicsCardDescription cannot exceed 255 characters.")]
		public string GraphicsCardDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "displayDescription is required.")]
		[MaxLength(255, ErrorMessage ="displayDescription cannot exceed 255 characters.")]
		public string DisplayDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "batteryDescription is required.")]
		[MaxLength(255, ErrorMessage ="batteryDescription cannot exceed 255 characters.")]
		public string BatteryDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = "wifiCardDescription is required.")]
		[MaxLength(255, ErrorMessage ="wifiCardDescription cannot exceed 255 characters.")]
		public string WifiCardDescription { get; set; } = String.Empty;
		
		[Required(ErrorMessage = " is required.")]
		[Range(0.0, double.MaxValue, ErrorMessage = "Weight must be greater than 0.")]
		public double Weight { get; set; } = 0.0;

		public bool IsActive { get; set; } = true;
	}
}
