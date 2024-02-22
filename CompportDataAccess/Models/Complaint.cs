using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompportDataAccess.Models;

public enum CargoStatus
{
    Base,
    NotReceived,
    Received,
    Processing,
    Shipped,
    Delivered
}

public enum ComplaintStatus
{
    Open,
    Support,
    Technician,
    CargoToTecnician,
    CargoToCustomer,
    Closed
}

public class Complaint
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get; set;
    }

    public int? UserId
    {
        get; set;
    }

    public User? User
    {
        get; set;
    }

    public string? PhoneNumber
    {
        get; set;
    }

    public int? DeviceId
    {
        get; set;
    }

    [ForeignKey("DeviceId")]
    public Device? Device { get; set; }

    public DateTime? Timestamp { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "description is required.")]
    [MaxLength(1000, ErrorMessage = "description cannot exceed 1000 characters.")]
    public string Description { get; set; } = String.Empty;

    //[Required(ErrorMessage = "chatRoom is required.")]
    //public ChatRoom ChatRoom { get; set; } = null!;
    public ICollection<Message> Messages { get; } = [];

    public ComplaintStatus Status { get; set; } = ComplaintStatus.Open;

    public CargoStatus CargoStatus { get; set; } = CargoStatus.Base;

    public bool IsActive { get; set; } = true;
}
