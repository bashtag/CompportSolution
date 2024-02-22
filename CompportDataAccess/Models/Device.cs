using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompportDataAccess.Models;

public class Device
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get; set;
    }

    // It is not necessary to specify a regular expression for the serial number or the computer model.
    // Brands provide their own serial number and model number.
    // /*
    // 	Serial Number Rules:
    // 		Start with two uppercase letters.
    // 		Followed by a hyphen (-).
    // 		Then four digits representing the year.
    // 		Another hyphen.
    // 		Two more digits for the month.
    // 		Yet another hyphen.
    // 		Finally, a four-digit sequence number.

    // 	For example: AB-2023-01-0001
    // */
    // [RegularExpression(@"^[A-Z]{2}-\d{4}-\d{2}-\d{4}$")]
    [Required(ErrorMessage = "serialNumber is required.")]
    [MaxLength(30, ErrorMessage = "serialNumber cannot exceed 30 characters.")]
    public string SerialNumber { get; set; } = string.Empty;

    public int ComputerModelId
    {
        get; set;
    }

    [ForeignKey("ComputerModelId")]
    public ComputerModel? ComputerModel
    {
        get; set;
    }

    public DateTime? PurchaseDate { get; set; } = DateTime.Now;

    public int? UserId
    {
        get; set;
    }

    public User? User
    {
        get; set;
    }

    public bool IsActive { get; set; } = true;
}