using CompportDataAccess.Models;
using CompportService.DTOs;
using CompportService.Interfaces;
using CompportService.Statics;
using Microsoft.AspNetCore.Mvc;

namespace CompportWebAPIController.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController(IAuthanticationService authanticationService,
                                IAccountManagementService accountManagementService) : ControllerBase
{
    private readonly IAuthanticationService _authanticationService = authanticationService;
    private readonly IAccountManagementService _accountManagementService = accountManagementService;

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginInfos)
    {
        try
        {
            await _authanticationService.GetUserAsync(loginInfos.Email);
        }
        catch (ArgumentNullException)
        {
            return NotFound("Kullanıcı Bulunamadı");
        }

        var (isAuth, user) = await _authanticationService.IsAuthanticatedAsync(loginInfos.Email, loginInfos.Password);
        if (isAuth)
        {
            return Ok(user);
        }
        return Unauthorized("Şifre Yanlış");
    }

    [HttpPost("RegisterCustomer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] User user)
    {
        var wrongInputs = await _accountManagementService.WrongInputHandler(user);
        if (wrongInputs.Count > 0)
        {
            return BadRequest(wrongInputs);
        }

        if (user.Role == UserRole.Admin)
            user.Role = UserRole.Customer;

        if (await _accountManagementService.RegisterUserAsync(user))
        {
            return Ok("User Registered");
        }
        return BadRequest("User Not Registered");
    }

    [HttpGet("GetCustomers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _accountManagementService.GetCustomersAsync();
        if (customers == null || customers.Count == 0)
        {
            return NotFound("No Customers Found");
        }
        return Ok(customers);
    }

    [HttpGet("GetSupports")]
    public async Task<IActionResult> GetSupports()
    {
        var supports = await _accountManagementService.GetSupportsAsync();
        if (supports == null || supports.Count == 0)
        {
            return NotFound("No Supports Found");
        }
        return Ok(supports);
    }
}
