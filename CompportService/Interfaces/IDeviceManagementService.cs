using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompportDataAccess.Models;

namespace CompportService.Interfaces;

public interface IDeviceManagementService
{
    Task<ICollection<ComputerModel>> GetExistingComputerModelsAsync();
    Task<ICollection<Device>> GetExistingDevicesByComputerModelAsync(int computerModelId);
    Task<Device?> GetDeviceByDeviceId(int deviceId);
    Task<bool> AddComputerModelAsync(ComputerModel computerModel);
    Task<bool> AddDeviceAsync(Device device);
    Task<bool> UpdateDeviceAsync(Device device);
    Task<bool> DeleteDeviceAsync(int deviceId);
    Task<ICollection<Device>> GetUserDevices(int userId);
}