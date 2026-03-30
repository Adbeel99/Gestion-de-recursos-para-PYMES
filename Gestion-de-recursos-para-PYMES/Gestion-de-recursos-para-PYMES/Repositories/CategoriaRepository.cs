using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Crear(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Editar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            _context.Categorias.Remove(ObtenerPorId(id));
            _context.SaveChanges();
        }

        public Categoria ObtenerPorId(int id)
        {
            return _context.Categorias.Find(id);
        }

        public List<Categoria> ObtenerTodos()
        {
            return _context.Categorias
                .Include(c => c.Productos)
                .ToList();
        }
    }
}