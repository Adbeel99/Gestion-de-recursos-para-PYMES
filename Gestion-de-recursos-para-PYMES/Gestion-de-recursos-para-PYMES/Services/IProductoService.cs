using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface IProductoService 
    {
        public void Crear(Producto producto);
        public void Editar(Producto producto);
        public void Eliminar(int id);
        public Producto ObtenerPorId(int id);
        public List<Producto> ObtenerTodos();

        public ProductoViewModel ObtenerProductoViewModel();
    }
}
