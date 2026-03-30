using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface IAccountService
    {
        Task<(bool succeeded, string? errorMessage)> LoginAsync(string email, string password, bool rememberMe);
        Task<(bool succeeded, IEnumerable<string> errors)> RegisterAsync(RegisterViewModel model);
        Task LogoutAsync();
        Task<string?> GetUserRoleAsync(string email);
    }
}