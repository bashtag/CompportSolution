using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompportDataAccess.Context;
using CompportDataAccess.Models;
using CompportService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompportService.Services.Privileges;

public class DeviceManagementService(AppDbContext context) : IDeviceManagementService
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AddComputerModelAsync(ComputerModel computerModel)
    {
        if (await IsComputerModelExistsAsync(computerModel))
        {
            return false;
        }

        await _context.ComputerModels.AddAsync(computerModel);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> IsComputerModelExistsAsync(ComputerModel computerModel)
    {
        return await _context.ComputerModels.AnyAsync(d => d.ModelNumber == computerModel.ModelNumber);
    }

    public async Task<bool> AddDeviceAsync(Device device)
    {
        if (device == null || await IsDeviceExistsAsync(device.Id))
        {
            return false;
        }

        await _context.Devices.AddAsync(device);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> IsDeviceExistsAsync(int deviceId)
    {
        return await _context.Devices.AnyAsync(d => d.Id == deviceId);
    }

    public async Task<ICollection<ComputerModel>> GetExistingComputerModelsAsync()
    {
        return await _context.ComputerModels.Where(d => d.IsActive == true).ToListAsync();
    }

    public async Task<ICollection<Device>> GetExistingDevicesByComputerModelAsync(int computerModelId) // efficient
    {
        var devicesWithComputerModel = await _context
            .Devices
            .Where(d => d.ComputerModel.Id == computerModelId && d.IsActive == true)
            .Include(d => d.ComputerModel)
            .ToListAsync();
        return await _context.Devices.Where(d => d.ComputerModel.Id == computerModelId && d.IsActive == true).ToListAsync();
    }

    public async Task<bool> UpdateDeviceAsync(Device device)
    {
        if (!await IsDeviceExistsAsync(device.Id))
        {
            return false;
        }
        _context.Devices.Update(device);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDeviceAsync(int deviceId)
    {
        var device = await _context.Devices.FindAsync(deviceId);
        if (device is null)
        {
            return false;
        }
        device.IsActive = false;
        _context.Devices.Update(device);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Device?> GetDeviceByDeviceId(int deviceId)
    {
        var device = await _context.Devices.FindAsync(deviceId);

        if (device is null)
        {
            return null;
        }

        device.ComputerModel = await _context.ComputerModels.FindAsync(device.ComputerModelId);
        return device;
    }

    public async Task<ICollection<Device>> GetUserDevices(int userId)
    {
        return await _context
            .Devices
            .Where(d => d.UserId == userId && d.IsActive)
            .Include(d => d.ComputerModel)
            .ToListAsync();
    }
}
