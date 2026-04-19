using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers
{
    [Route("api/reportes")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ReportesController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("productos-stock")]
        public IActionResult ProductosConStock()
        {
            var productos = _productoService.ObtenerTodos()
                .Select(p => new
                {
                    p.Nombre,
                    p.Existencias
                })
                .OrderByDescending(p => p.Existencias)
                .Take(5);

            return Ok(productos);
        }
    }
}