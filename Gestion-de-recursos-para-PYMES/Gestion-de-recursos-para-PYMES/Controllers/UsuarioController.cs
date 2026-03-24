using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("usuarios")]
    [Authorize(Roles = Roles.Administrador)]
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;

        public UsuarioController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var usuarios = _userManager.Users.ToList();
            var lista = new List<UsuarioViewModel>();

            foreach (var u in usuarios)
            {
                var roles = await _userManager.GetRolesAsync(u);
                lista.Add(new UsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Email = u.Email,
                    RolActual = roles.FirstOrDefault() ?? "Sin rol"
                });
            }

            return View(lista);
        }

        [HttpGet("cambiar-rol/{id}")]
        public async Task<IActionResult> CambiarRol(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            var model = new CambiarRolViewModel
            {
                UsuarioId = user.Id,
                Nombre = user.Nombre,
                Apellidos = user.Apellidos,
                Email = user.Email,
                RolActual = roles.FirstOrDefault() ?? "Sin rol"
            };

            return View(model);
        }

        [HttpPost("cambiar-rol/{id}")]
        public async Task<IActionResult> CambiarRol(CambiarRolViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UsuarioId.ToString());
            if (user == null)
                return NotFound();

            var rolesActuales = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, rolesActuales);
            await _userManager.AddToRoleAsync(user, model.NuevoRol);

            return RedirectToAction("Index");
        }
    }
}