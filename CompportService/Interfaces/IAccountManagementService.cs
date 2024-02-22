using CompportDataAccess.Models;

namespace CompportService.Interfaces
{
	public interface IAccountManagementService
	{
		Task<bool> RegisterUserAsync(User user);
        Task<Dictionary<string, string>> WrongInputHandler(User user);
        Task<ICollection<User>> GetCustomersAsync();
        Task<ICollection<User>> GetSupportsAsync();
    }
}
