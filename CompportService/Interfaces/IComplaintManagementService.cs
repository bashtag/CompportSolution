using CompportDataAccess.Models;

namespace CompportService.Interfaces;

public interface IComplaintManagementService
{
    Task<bool> AddComplaintAsync(Complaint complaint);
    Task<ICollection<Complaint>> GetExistingComplaintsAsync();
    Task<bool> AddMessageToComplaintAsync(Complaint complaint, Message message);
    Task<bool> UpdateComplaintAsync(Complaint complaint);
    Task<bool> DeleteComplaintAsync(Complaint complaint);
    Task<ICollection<Complaint>> GetComplaintsByUserId(int userId);
}