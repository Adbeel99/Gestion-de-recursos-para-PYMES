using Gestion_de_recursos_para_PYMES.Data;
using Gestion_de_recursos_para_PYMES.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Crear(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Editar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var c = ObtenerPorId(id);
            if (c == null) return;
            _context.Clientes.Remove(c);
            _context.SaveChanges();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }
    }
}
