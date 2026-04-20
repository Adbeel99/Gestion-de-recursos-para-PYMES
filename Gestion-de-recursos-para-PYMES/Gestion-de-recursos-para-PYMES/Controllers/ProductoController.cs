using Gestion_de_recursos_para_PYMES.Constants;
using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("producto")]
    [Authorize(Roles = $"{Roles.Administrador},{Roles.Almacenista}")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var productos = _productoService.ObtenerTodos();
            var alertaStock = _productoService.ObtenerEnStockMinimo()
                .Select(p => p.Nombre)
                .ToList();

            ViewBag.AlertaStock = alertaStock;
            return View(productos);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(_productoService.ObtenerProductoViewModel());
        }

        [HttpPost("crear")]
        public IActionResult Crear(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_productoService.ObtenerProductoViewModel());

            _productoService.Crear(model.Producto);
            return RedirectToAction("Index");
        }

        [HttpGet("detalle/{id}")]
        public IActionResult Detalle(int id)
        {
            if (id <= 0)
                return BadRequest("Id no válido");

            var producto = _productoService.ObtenerPorId(id);
            if (producto == null)
                return NotFound("Producto no encontrado");

            var model = _productoService.ObtenerProductoViewModel();
            model.Producto = producto;
            return View(model);
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Detalle", _productoService.ObtenerProductoViewModel());

            _productoService.Editar(model.Producto);
            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id}")]
        [Authorize(Roles = Roles.Administrador)]
        public IActionResult EliminarConfirmado(int id)
        {
            _productoService.Eliminar(id);
            return RedirectToAction("Index");
        }
        [HttpGet("buscar")]
        public IActionResult Buscar(string termino)
        {
            var productos = _productoService.Buscar(termino);

            var resultado = productos.Select(p => new
            {
                p.ProductoId,
                p.CodigoSKU,
                p.Nombre,
                p.PrecioVenta,
                p.Existencias,
                Categoria = p.Categoria != null ? p.Categoria.Nombre : ""
            });

            return Json(resultado);
        }
    }
}