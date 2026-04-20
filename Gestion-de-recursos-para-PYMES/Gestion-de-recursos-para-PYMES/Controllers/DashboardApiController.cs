using Gestion_de_recursos_para_PYMES.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_recursos_para_PYMES.Controllers.Api
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardApiController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IOrdenVentaService _ordenService;

        public DashboardApiController(
            IProductoService productoService,
            IOrdenVentaService ordenService)
        {
            _productoService = productoService;
            _ordenService = ordenService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(new { message = "Dashboard API" });
        }

        [HttpGet("stock-bajo")]
        public IActionResult StockBajo()
        {
            var productos = _productoService.ObtenerTodos()
                .Select(p => new
                {
                    p.Nombre,
                    p.Existencias,
                    p.ExistenciasMinimas
                });

            return Ok(productos);
        }

       

        [HttpGet("producto-mas-vendido")]
        public IActionResult ProductoMasVendido()
        {
            var resultado = _ordenService.ObtenerTodas()
                .SelectMany(o => o.Detalles)
                .GroupBy(d => new { d.ProductoId, d.Producto.Nombre })
                .Select(g => new
                {
                    g.Key.Nombre,
                    TotalVendido = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(p => p.TotalVendido)
                .ToList();

            return Ok(resultado);
        }

        
    }
}