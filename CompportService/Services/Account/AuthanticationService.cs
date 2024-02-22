using System.Security.Cryptography;
using System.Text;
using CompportDataAccess.Context;
using CompportDataAccess.Models;
using CompportService.Interfaces;
using CompportService.Statics;
using Microsoft.EntityFrameworkCore;

namespace CompportService.Services.Account;

public class AuthanticationService(AppDbContext context) : IAuthanticationService
{
    private readonly AppDbContext _context = context
        ?? throw new ArgumentNullException(nameof(context));

    public async Task<User> GetUserAsync(string email)
    {
        return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email)
                ?? throw new ArgumentNullException(nameof(email));
    }

    public async Task<(bool, User?)> IsAuthanticatedAsync(string email, string password)
    {
        var user = await GetUserAsync(email);
        var passwordHash = AccountStatics.HashPassword(password);

        return (user != null && user.PasswordHash == passwordHash, user);
    }
}