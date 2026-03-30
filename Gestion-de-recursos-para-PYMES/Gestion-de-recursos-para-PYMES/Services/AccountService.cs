using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.AspNetCore.Identity;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AccountService(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool succeeded, string? errorMessage)> LoginAsync(
            string email, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, rememberMe, lockoutOnFailure: false);

            return result.Succeeded
                ? (true, null)
                : (false, "Correo o contraseña incorrectos");
        }

        public async Task<(bool succeeded, IEnumerable<string> errors)> RegisterAsync(
            RegisterViewModel model)
        {
            var user = new Usuario
            {
                UserName = model.Email,
                Email = model.Email,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description));

            await _userManager.AddToRoleAsync(user, Roles.Vendedor);
            return (true, Enumerable.Empty<string>());
        }

        public async Task LogoutAsync()
            => await _signInManager.SignOutAsync();

        public async Task<string?> GetUserRoleAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }
    }
}