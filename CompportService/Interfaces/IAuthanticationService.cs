using CompportDataAccess.Models;

namespace CompportService.Interfaces
{
    public interface IAuthanticationService
    {
        Task<User> GetUserAsync(string email);
        Task<(bool, User?)> IsAuthanticatedAsync(string email, string password);
    }
}
