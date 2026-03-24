using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ApplicationDbContext _context; 

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }   

        public void Crear(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void Editar(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            _context.Productos.Remove(ObtenerPorId(id));
            _context.SaveChanges();
        }

        public Producto ObtenerPorId(int id)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.ProductoId == id);
        }

        public List<Producto> ObtenerTodos()
         => _context.Productos
                .Include(p => p.Categoria)
                .ToList(); 
        
    }
}
