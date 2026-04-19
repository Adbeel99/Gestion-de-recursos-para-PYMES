using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface IProductoService
    {
        void Crear(Producto producto);
        void Editar(Producto producto);
        void Eliminar(int id);
        Producto ObtenerPorId(int id);
        List<Producto> ObtenerTodos();
        List<Producto> Buscar(string termino);
        ProductoViewModel ObtenerProductoViewModel();
    }
}