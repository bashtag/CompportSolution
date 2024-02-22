using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompportDataAccess.Models
{
	public class Message
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "sender is required.")]
		public User Sender { get; set; } = null!;

		//[Required(ErrorMessage = "chatRoom is required.")]
		//public ChatRoom ChatRoom { get; set; } = null!;

		[Required(ErrorMessage = "content is required.")]
		[MaxLength(1000, ErrorMessage = "content cannot exceed 100 characters.")]
		public string Content { get; set; } = string.Empty;
		public DateTime ?Timestamp { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
	}
}