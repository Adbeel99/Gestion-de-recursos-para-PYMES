using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class OrdenVentaRepository : IOrdenVentaRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenVentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CrearOrden(OrdenVenta orden)
        {
            _context.OrdenesVenta.Add(orden);
            _context.SaveChanges();
        }

        public void ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public List<OrdenVenta> ObtenerTodas()
        {
            return _context.OrdenesVenta
                .Include(o => o.Cliente)
                .Include(o => o.Usuario)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                .OrderByDescending(o => o.Fecha)
                .ToList();
        }

        public List<OrdenVenta> ObtenerPorUsuario(int usuarioId)
        {
            return _context.OrdenesVenta
                .Include(o => o.Cliente)
                .Include(o => o.Usuario)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                .Where(o => o.UsuarioId == usuarioId)
                .OrderByDescending(o => o.Fecha)
                .ToList();
        }

        public OrdenVenta ObtenerPorId(int id)
        {
            return _context.OrdenesVenta
                .Include(o => o.Cliente)
                .Include(o => o.Usuario)
                .Include(o => o.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefault(o => o.OrdenId == id);
        }
    }
}