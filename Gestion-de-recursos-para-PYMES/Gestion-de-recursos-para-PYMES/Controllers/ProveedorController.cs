using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("proveedor")]
    [Authorize(Roles = Roles.Administrador)]
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var proveedores = _proveedorService.ObtenerTodos();
            return View(proveedores);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View(proveedor);
            _proveedorService.Crear(proveedor);
            return RedirectToAction("Index");
        }

        [HttpGet("detalle/{id}")]
        public IActionResult Detalle(int id)
        {
            if (id <= 0)
                return BadRequest("Id no válido");
            var proveedor = _proveedorService.ObtenerPorId(id);
            if (proveedor == null)
                return NotFound("Proveedor no encontrado");
            return View(proveedor);
        }

        [HttpPost("editar")]
        public IActionResult Editar(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View("Detalle", proveedor);
            _proveedorService.Editar(proveedor);
            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id}")]
        public IActionResult EliminarConfirmado(int id)
        {
            _proveedorService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}