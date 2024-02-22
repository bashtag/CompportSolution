using CompportDataAccess.Models;

namespace CompportService.DTOs;
public class AddMessageToComplaintDTO
{
    public Complaint complaint
    {
        get; set;
    }
    public Message message
    {
        get; set;
    }
}