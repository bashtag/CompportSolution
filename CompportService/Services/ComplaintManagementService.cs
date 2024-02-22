using CompportDataAccess.Context;
using CompportDataAccess.Models;
using CompportService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompportService.Services;

public class ComplaintManagementService(AppDbContext context, IDeviceManagementService deviceManagementService) : IComplaintManagementService
{
    private readonly AppDbContext _context = context;
    private readonly IDeviceManagementService _deviceManagementService = deviceManagementService;

    public async Task<bool> AddComplaintAsync(Complaint complaint)
    {
        if (await IsComplaintExistsAsync(complaint))
        {
            return false;
        }
        await _deviceManagementService.AddDeviceAsync(complaint.Device);

        await _context.Complaints.AddAsync(complaint);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> IsComplaintExistsAsync(Complaint complaint)
    {
        return await _context.Complaints.AnyAsync(c => c.Id == complaint.Id);
    }

    private static bool HasComplaintPhoneNumberAsync(Complaint complaint)
    {
        return complaint.PhoneNumber != null;
    }

    public async Task<ICollection<Complaint>> GetExistingComplaintsAsync()
    {
        //var debug = await _context
        //    .Complaints
        //    .Where(c => c.IsActive == true)
        //    .Include(c => c.Device)
        //    .ToListAsync();
        //Console.WriteLine(debug);
        return await _context
            .Complaints
            .Where(c => c.IsActive == true)
            .Include(c => c.Device)
                .ThenInclude(d => d.ComputerModel)
            .ToListAsync();
    }

    public async Task<bool> AddMessageToComplaintAsync(Complaint complaint, Message message)
    {
        if (!await IsComplaintExistsAsync(complaint))
        {
            return false;
        }
        complaint.Messages.Add(message);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateComplaintAsync(Complaint complaint)
    {
        if (!await IsComplaintExistsAsync(complaint))
        {
            return false;
        }
        _context.Complaints.Update(complaint);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteComplaintAsync(Complaint complaint)
    {
        if (!await IsComplaintExistsAsync(complaint))
        {
            return false;
        }
        complaint.IsActive = false;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<ICollection<Complaint>> GetComplaintsByUserId(int userId)
    {
        return await _context
            .Complaints
            .Where(c => c.IsActive && c.UserId == userId)
            .Include(c => c.Device)
                .ThenInclude(d => d.ComputerModel)
            .ToListAsync();
    }
}