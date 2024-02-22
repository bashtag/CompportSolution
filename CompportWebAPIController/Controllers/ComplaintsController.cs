using CompportDataAccess.Models;
using CompportService.DTOs;
using CompportService.Interfaces;
using CompportService.Statics;
using Microsoft.AspNetCore.Mvc;

namespace CompportWebAPIController.Controllers;

[Route("[controller]")]
[ApiController]
public class ComplaintsController(IComplaintManagementService service) : ControllerBase
{
    private readonly IComplaintManagementService _complaintManagementService = service;

    [HttpPost("AddComplaint")]
    public async Task<IActionResult> AddComplaint([FromBody] Complaint complaint)
    {
        if (complaint.PhoneNumber != null && complaint.PhoneNumber != "" && !AccountStatics.IsPhoneNumberValid(complaint.PhoneNumber))
        {
            return BadRequest("Telefon numarası geçersiz.");
        }
        if (await _complaintManagementService.AddComplaintAsync(complaint))
        {
            return Ok("Şikayet eklendi.");
        }
        return BadRequest("Şikayet zaten var.");
    }

    [HttpGet("GetExistingComplaints")]
    public async Task<IActionResult> GetExistingComplaints()
    {
        var result = await _complaintManagementService.GetExistingComplaintsAsync();
        if (result == null || result.Count == 0)
        {
            return BadRequest("Hiç şikayet yok.");
        }
        return Ok(result);
    }

    [HttpPost("AddMessageToComplaint")]
    public async Task<IActionResult> AddMessageToComplaint([FromBody] AddMessageToComplaintDTO dto)
    {
        if (await _complaintManagementService.AddMessageToComplaintAsync(dto.complaint, dto.message))
        {
            return Ok("Mesaj eklendi.");
        }
        return BadRequest("Şikayet olmadığı için mesaj eklenemedi.");
    }

    [HttpPut("UpdateComplaint")]
    public async Task<IActionResult> UpdateComplaint([FromBody] Complaint complaint)
    {
        if (complaint.PhoneNumber != null && complaint.PhoneNumber != "" && AccountStatics.IsPhoneNumberValid(complaint.PhoneNumber))
        {
            return BadRequest("Telefon numarası geçersiz.");
        }
        if (await _complaintManagementService.UpdateComplaintAsync(complaint))
        {
            return Ok("Şikayet güncellendi.");
        }
        return BadRequest("Şikayet bulunamadı.");
    }

    [HttpPost("DeleteComplaint")]
    public async Task<IActionResult> DeleteComplaint([FromBody] Complaint complaint)
    {
        if (await _complaintManagementService.DeleteComplaintAsync(complaint))
        {
            return Ok("Şikayet silindi.");
        }
        return BadRequest("Şikayet bulunamadı.");
    }

    [HttpGet("GetComplaintsByUserId")]
    public async Task<IActionResult> GetComplaintsByUserId(int userId)
    {
        var result = await _complaintManagementService.GetComplaintsByUserId(userId);
        if (result == null || result.Count == 0)
        {
            return BadRequest("Bu kullanıcıya ait hiç şikayet yok.");
        }
        return Ok(result);
    }
}