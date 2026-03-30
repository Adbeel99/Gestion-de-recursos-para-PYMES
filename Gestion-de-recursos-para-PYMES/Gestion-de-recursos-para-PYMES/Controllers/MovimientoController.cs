using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("movimiento")]
    [Authorize(Roles = $"{Roles.Administrador},{Roles.Almacenista}")]
    public class MovimientoController : Controller
    {
        private readonly IMovimientoService _movimientoService;
        private readonly UserManager<Usuario> _userManager;

        public MovimientoController(
            IMovimientoService movimientoService,
            UserManager<Usuario> userManager)
        {
            _movimientoService = movimientoService;
            _userManager = userManager;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var movimientos = _movimientoService.ObtenerTodos();
            return View(movimientos);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(_movimientoService.ObtenerMovimientoViewModel());
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(MovimientoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_movimientoService.ObtenerMovimientoViewModel());

            var user = await _userManager.GetUserAsync(User);

            try
            {
                _movimientoService.RegistrarMovimiento(model, user!.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(_movimientoService.ObtenerMovimientoViewModel());
            }
        }
    }
}