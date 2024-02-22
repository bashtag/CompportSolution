using CompportDataAccess.Models;
using CompportService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompportWebAPIController.Controllers;

[Route("[controller]")]
[ApiController]
public class AdminSystemController(IDeviceManagementService deviceManagementService) : ControllerBase
{
    private readonly IDeviceManagementService _deviceManagementService = deviceManagementService;

    [HttpPost("AddComputerModel")]
    public async Task<IActionResult> AddComputerModel(ComputerModel computerModel)
    {
        var result = await _deviceManagementService.AddComputerModelAsync(computerModel);
        if (!result)
        {
            return BadRequest("Bu bilgisayar modeli zaten var.");
        }
        return Ok(result);
    }

    [HttpPost("AddDevice")]
    public async Task<IActionResult> AddDevice(Device device)
    {
        var result = await _deviceManagementService.AddDeviceAsync(device);
        if (!result)
        {
            return BadRequest("Bu cihaz zaten var.");
        }
        return Ok(result);
    }

    [HttpGet("GetExistingComputerModels")]
    public async Task<IActionResult> GetExistingComputerModels()
    {
        var result = await _deviceManagementService.GetExistingComputerModelsAsync();
        if (result == null || result.Count == 0)
        {
            return BadRequest("Hiç bilgisayar modeli yok.");
        }
        return Ok(result);
    }

    [HttpGet("GetExistingDevicesByComputerModel")]
    public async Task<IActionResult> GetExistingDevicesByComputerModel(int computerModelId)
    {
        var result = await _deviceManagementService.GetExistingDevicesByComputerModelAsync(computerModelId);
        if (result == null || result.Count == 0)
        {
            return BadRequest("Bu model için hiç cihaz yok.");
        }
        return Ok(result);
    }

    [HttpPut("UpdateDevice")]
    public async Task<IActionResult> UpdateDevice(Device device)
    {
        var result = await _deviceManagementService.UpdateDeviceAsync(device);
        if (!result)
        {
            return BadRequest("Cihaz bulunamadý.");
        }
        return Ok(result);
    }

    [HttpDelete("DeleteDevice")]
    public async Task<IActionResult> DeleteDevice(int deviceId)
    {
        var result = await _deviceManagementService.DeleteDeviceAsync(deviceId);
        if (!result)
        {
            return BadRequest("Cihaz bulunamadý.");
        }
        return Ok(result);
    }

    [HttpGet("GetDevicesByUserId")]
    public async Task<IActionResult> GetDevicesByUserId(int userId)
    {
        var result = await _deviceManagementService.GetUserDevices(userId);
        if (result == null || result.Count == 0)
        {
            return BadRequest("Bu kullanýcýya ait cihaz yok.");
        }
        return Ok(result);
    }
}