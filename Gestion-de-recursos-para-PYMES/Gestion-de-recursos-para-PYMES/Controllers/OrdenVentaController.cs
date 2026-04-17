using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("ordenventa")]
    [Authorize(Roles = $"{Roles.Administrador},{Roles.Vendedor}")]
    public class OrdenVentaController : Controller
    {
        private readonly IOrdenVentaService _ordenService;
        private readonly UserManager<Usuario> _userManager;

        public OrdenVentaController(
            IOrdenVentaService ordenService,
            UserManager<Usuario> userManager)
        {
            _ordenService = ordenService;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Roles.Administrador))
                return View(_ordenService.ObtenerTodas());

            var user = await _userManager.GetUserAsync(User);
            return View(_ordenService.ObtenerPorUsuario(user!.Id));
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(_ordenService.ObtenerOrdenVentaViewModel());
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(OrdenVentaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_ordenService.ObtenerOrdenVentaViewModel());

            var user = await _userManager.GetUserAsync(User);

            try
            {
                _ordenService.CrearOrden(model, user!.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(_ordenService.ObtenerOrdenVentaViewModel());
            }
        }

        [HttpGet("detalle/{id}")]
        public IActionResult Detalle(int id)
        {
            if (id <= 0)
                return BadRequest("Id no válido");

            var orden = _ordenService.ObtenerPorId(id);
            if (orden == null)
                return NotFound("Orden no encontrada");

            return View(orden);
        }
    }
}