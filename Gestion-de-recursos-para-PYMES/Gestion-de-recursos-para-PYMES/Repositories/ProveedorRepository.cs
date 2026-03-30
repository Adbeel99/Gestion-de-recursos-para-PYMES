using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Crear(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
        }

        public void Editar(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            _context.Proveedores.Remove(ObtenerPorId(id));
            _context.SaveChanges();
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _context.Proveedores.Find(id);
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _context.Proveedores.ToList();
        }
    }
}