using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public interface ICategoriaRepository
    {
        void Crear(Categoria categoria);
        void Editar(Categoria categoria);
        void Eliminar(int id);
        Categoria ObtenerPorId(int id);
        List<Categoria> ObtenerTodos();
    }
}