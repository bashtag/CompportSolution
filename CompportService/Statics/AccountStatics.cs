using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace CompportService.Statics;
public static class AccountStatics
{
    public static string HashPassword(string password)
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA512;

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            Array.Empty<byte>(),
            iterations,
            hashAlgorithmName,
            keySize
        );

        return Convert.ToHexString(hash);
    }

    public static bool IsPasswordValid(string password)
    {
        return password.Length >= 8
            && password.Length <= 20
            && password.Any(c => char.IsDigit(c))
            && password.Any(c => char.IsLetter(c))
            && password.Any(c => !char.IsLetterOrDigit(c))
            && password.Any(c => char.IsUpper(c))
            && password.Any(c => char.IsLower(c))
            && !password.Any(c => char.IsWhiteSpace(c));
    }

    public static bool IsEmailValid(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return mailAddress.Address == email;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsPhoneNumberValid(string phoneNumber)
    {
        return phoneNumber.All(c => char.IsDigit(c)) && (phoneNumber.Length == 10 || phoneNumber.Length == 11);
    }
}
