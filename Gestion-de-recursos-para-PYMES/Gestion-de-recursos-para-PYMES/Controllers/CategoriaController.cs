using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("categorias")]
    [Authorize(Roles = Roles.Administrador)]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var categorias = _categoriaService.ObtenerTodos();
            return View(categorias);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);
            _categoriaService.Crear(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet("detalle/{id}")]
        public IActionResult Detalle(int id)
        {
            var categoria = _categoriaService.ObtenerPorId(id);
            if (categoria == null)
                return NotFound();
            return View(categoria);
        }

        [HttpPost("editar")]
        public IActionResult Editar(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return View("Detalle", categoria);
            _categoriaService.Editar(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            var categoria = _categoriaService.ObtenerPorId(id);
            if (categoria == null)
                return NotFound();
            return View(categoria);
        }

        [HttpPost("eliminar/{id}")]
        public IActionResult EliminarConfirmado(int id)
        {
            _categoriaService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}