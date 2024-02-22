using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompportDataAccess.Models
{
	public class ChatRoom
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "name is required.")]
		[MaxLength(100, ErrorMessage = "name cannot exceed 100 characters.")]
		public string Name { get; set; } = string.Empty;

		public ICollection<Message> Messages { get; } = new List<Message>();
		
		public bool IsActive { get; set; } = true;
	}
}