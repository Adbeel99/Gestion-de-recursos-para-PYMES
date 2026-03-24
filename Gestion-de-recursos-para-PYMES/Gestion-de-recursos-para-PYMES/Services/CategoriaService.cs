using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Crear(Categoria categoria)
        {
            _categoriaRepository.Crear(categoria);
        }

        public void Editar(Categoria categoria)
        {
            _categoriaRepository.Editar(categoria);
        }

        public void Eliminar(int id)
        {
            _categoriaRepository.Eliminar(id);
        }

        public Categoria ObtenerPorId(int id)
        {
            return _categoriaRepository.ObtenerPorId(id);
        }

        public List<Categoria> ObtenerTodos()
        {
            return _categoriaRepository.ObtenerTodos();
        }
    }
}