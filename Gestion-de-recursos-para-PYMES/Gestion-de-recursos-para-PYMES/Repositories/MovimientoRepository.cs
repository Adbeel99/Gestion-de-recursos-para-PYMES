using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly ApplicationDbContext _context;

        public MovimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CrearMovimiento(MovimientoInventario movimiento)
        {
            _context.MovimientosInventario.Add(movimiento);
            _context.SaveChanges();
        }

        public void ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public List<MovimientoInventario> ObtenerTodos()
        {
            return _context.MovimientosInventario
                .Include(m => m.Usuario)
                .Include(m => m.Proveedor)
                .Include(m => m.Detalles)
                    .ThenInclude(d => d.Producto)
                .OrderByDescending(m => m.Fecha)
                .ToList();
        }

        public List<MovimientoInventario> ObtenerPorProducto(int productoId)
        {
            return _context.MovimientosInventario
                .Include(m => m.Usuario)
                .Include(m => m.Proveedor)
                .Include(m => m.Detalles)
                    .ThenInclude(d => d.Producto)
                .Where(m => m.Detalles.Any(d => d.ProductoId == productoId))
                .OrderByDescending(m => m.Fecha)
                .ToList();
        }
    }
}