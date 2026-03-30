using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public void Crear(Proveedor proveedor)
        {
            _proveedorRepository.Crear(proveedor);
        }

        public void Editar(Proveedor proveedor)
        {
            _proveedorRepository.Editar(proveedor);
        }

        public void Eliminar(int id)
        {
            _proveedorRepository.Eliminar(id);
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _proveedorRepository.ObtenerPorId(id);
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _proveedorRepository.ObtenerTodos();
        }
    }
}