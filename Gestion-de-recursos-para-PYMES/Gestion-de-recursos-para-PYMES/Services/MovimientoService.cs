using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepo;
        private readonly IProductoRepository _productoRepo;
        private readonly IProveedorRepository _proveedorRepo;

        public MovimientoService(
            IMovimientoRepository movimientoRepo,
            IProductoRepository productoRepo,
            IProveedorRepository proveedorRepo)
        {
            _movimientoRepo = movimientoRepo;
            _productoRepo = productoRepo;
            _proveedorRepo = proveedorRepo;
        }

        public void RegistrarMovimiento(MovimientoViewModel model, int usuarioId)
        {
            var producto = _productoRepo.ObtenerPorId(model.ProductoId);

            if (producto == null)
                throw new Exception("Producto no encontrado");

            if (model.Tipo == "Salida" && producto.Existencias < model.Cantidad)
                throw new Exception("Stock insuficiente");

            var detalle = new DetalleMovimiento
            {
                ProductoId = model.ProductoId,
                Cantidad = model.Cantidad
            };

            var movimiento = new MovimientoInventario
            {
                Tipo = model.Tipo,
                Observaciones = model.Observaciones,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId,
                ProveedorId = model.ProveedorId,
                Detalles = new List<DetalleMovimiento> { detalle }
            };

            _movimientoRepo.CrearMovimiento(movimiento);

            if (model.Tipo == "Entrada")
                producto.Existencias += model.Cantidad;
            else
                producto.Existencias -= model.Cantidad;

            _movimientoRepo.ActualizarProducto(producto);
        }

        public List<MovimientoInventario> ObtenerTodos()
            => _movimientoRepo.ObtenerTodos();

        public List<MovimientoInventario> ObtenerPorProducto(int productoId)
            => _movimientoRepo.ObtenerPorProducto(productoId);

        public MovimientoViewModel ObtenerMovimientoViewModel()
        {
            return new MovimientoViewModel
            {
                Productos = _productoRepo.ObtenerTodos()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ProductoId.ToString(),
                        Text = p.Nombre
                    }).ToList(),
                Proveedores = _proveedorRepo.ObtenerTodos()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ProveedorId.ToString(),
                        Text = p.Nombre
                    }).ToList()
            };
        }
    }
}