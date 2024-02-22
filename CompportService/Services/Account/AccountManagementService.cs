
using CompportDataAccess.Context;
using CompportDataAccess.Models;
using CompportService.Interfaces;
using CompportService.Statics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CompportService.Services.Account;

public class AccountManagementService(IAuthanticationService authanticationService,
                                        AppDbContext context) : IAccountManagementService
{
    private readonly IAuthanticationService _authanticationService = authanticationService;
    private readonly AppDbContext _context = context
        ?? throw new ArgumentNullException(nameof(context));

    private async Task<bool> IsEmailExistsOrNotValid(string email)
    {
        try
        {
            await _authanticationService.GetUserAsync(email);
        }
        catch (ArgumentNullException)
        {
            return !AccountStatics.IsEmailValid(email);
        }
        return false;
    }

    private async Task<bool> IsNumberExistsOrNotValid(string number)
    {
        return await _context.Users.Where(u => u.Phone == number).FirstOrDefaultAsync() != null
            || !AccountStatics.IsPhoneNumberValid(number);
    }

    public async Task<bool> RegisterUserAsync(User user)
    {
        user.PasswordHash = AccountStatics.HashPassword(user.PasswordHash);
        if (await IsEmailExistsOrNotValid(user.Email))
        {
            return false;
        }

        if (await IsNumberExistsOrNotValid(user.Phone))
        {
            return false;
        }

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public async Task<Dictionary<string, string>> WrongInputHandler(User user)
    {
        var wrongInputs = new Dictionary<string, string>();
        if (await IsEmailExistsOrNotValid(user.Email))
        {
            wrongInputs.Add("Email", "e-posta zaten var veya geçerli deðil");
        }

        if (await IsNumberExistsOrNotValid(user.Phone))
        {
            wrongInputs.Add("Phone", "telefon numarasý geçerli deðil");
        }

        if (!AccountStatics.IsPasswordValid(user.PasswordHash))
        {
            wrongInputs.Add("Password",
                "þifre: 8-20 karakter sayýsýnda;\n" +
                "en az 1 özel karakter, alfabetik karakter,\n" +
                "numerik karakter, büyük ve küçük harf içerip\n" +
                "boþluk olmamalýdýr");
        }
        return wrongInputs;
    }

    public async Task<ICollection<User>> GetCustomersAsync()
    {
        return await _context.Users.Where(u => u.Role == UserRole.Customer).ToListAsync();
    }

    public async Task<ICollection<User>> GetSupportsAsync()
    {
        return await _context
            .Users
            .Where(u => u.Role == UserRole.CustomerSupport || u.Role == UserRole.Technician)
            .ToListAsync();
    }
}
