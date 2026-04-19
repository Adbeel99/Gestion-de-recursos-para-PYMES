using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class OrdenVentaService : IOrdenVentaService
    {
        private readonly IOrdenVentaRepository _ordenRepo;
        private readonly IProductoRepository _productoRepo;
        private readonly IClienteRepository _clienteRepo;

        public OrdenVentaService(
            IOrdenVentaRepository ordenRepo,
            IProductoRepository productoRepo,
            IClienteRepository clienteRepo)
        {
            _ordenRepo = ordenRepo;
            _productoRepo = productoRepo;
            _clienteRepo = clienteRepo;
        }

        public void CrearOrden(OrdenVentaViewModel model, int usuarioId)
        {
            if (model.Detalles == null || !model.Detalles.Any())
                throw new Exception("Debe agregar al menos un producto");

            decimal total = 0;

            foreach (var detalle in model.Detalles)
            {
                var producto = _productoRepo.ObtenerPorId(detalle.ProductoId);

                if (producto == null)
                    throw new Exception("Producto no encontrado");

                if (producto.Existencias < detalle.Cantidad)
                    throw new Exception($"Stock insuficiente para {producto.Nombre}");

                total += producto.PrecioVenta * detalle.Cantidad;
            }

            var detalles = model.Detalles.Select(d => new DetalleVenta
            {
                ProductoId = d.ProductoId,
                Cantidad = d.Cantidad
            }).ToList();

            var orden = new OrdenVenta
            {
                ClienteId = model.ClienteId,
                UsuarioId = usuarioId,
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                Total = total,
                Detalles = detalles
            };

            _ordenRepo.CrearOrden(orden);

            foreach (var detalle in model.Detalles)
            {
                var producto = _productoRepo.ObtenerPorId(detalle.ProductoId);
                producto.Existencias -= detalle.Cantidad;
                _ordenRepo.ActualizarProducto(producto);
            }
        }

        public List<OrdenVenta> ObtenerTodas()
            => _ordenRepo.ObtenerTodas();

        public List<OrdenVenta> ObtenerPorUsuario(int usuarioId)
            => _ordenRepo.ObtenerPorUsuario(usuarioId);

        public OrdenVenta ObtenerPorId(int id)
            => _ordenRepo.ObtenerPorId(id);

        public OrdenVentaViewModel ObtenerOrdenVentaViewModel()
        {
            return new OrdenVentaViewModel
            {
                Clientes = _clienteRepo.ObtenerTodos()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nombre
                    }).ToList(),
                Productos = _productoRepo.ObtenerTodos()
                    .Select(p => new SelectListItem
                    {
                        Value = p.ProductoId.ToString(),
                        Text = $"{p.Nombre} (Stock: {p.Existencias})"
                    }).ToList()
            };
        }
    }
}