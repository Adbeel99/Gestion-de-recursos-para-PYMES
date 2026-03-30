using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface ICategoriaService
    {

        public void Crear(Categoria categoria);
        public void Editar(Categoria categoria);
        public void Eliminar(int id);
        public Categoria ObtenerPorId(int id);
        public List<Categoria> ObtenerTodos();
    }
}
