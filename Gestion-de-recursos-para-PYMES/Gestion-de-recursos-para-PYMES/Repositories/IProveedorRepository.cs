using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public interface IProveedorRepository
    {
        void Crear(Proveedor proveedor);
        void Editar(Proveedor proveedor);
        void Eliminar(int id);
        Proveedor ObtenerPorId(int id);
        List<Proveedor> ObtenerTodos();
    }
}