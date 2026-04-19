using Gestion_de_recursos_para_PYMES.Models;
using Gestion_de_recursos_para_PYMES.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProductoService(
            IProductoRepository productoRepository,
            ICategoriaRepository categoriaRepository)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public void Crear(Producto producto)
        {
            _productoRepository.Crear(producto);
        }

        public void Editar(Producto producto)
        {
            _productoRepository.Editar(producto);
        }

        public void Eliminar(int id)
        {
            _productoRepository.Eliminar(id);
        }

        public Producto ObtenerPorId(int id)
        {
            return _productoRepository.ObtenerPorId(id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepository.ObtenerTodos();
        }

        public ProductoViewModel ObtenerProductoViewModel()
        {
            var categorias = _categoriaRepository.ObtenerTodos()
                .Select(c => new SelectListItem
                {
                    Value = c.CategoriaId.ToString(),
                    Text = c.Nombre
                });

            return new ProductoViewModel { Categorias = categorias };
        }
        public List<Producto> Buscar(string termino)
        {
            var productos = _productoRepository.ObtenerTodos();

            if (!string.IsNullOrEmpty(termino))
            {
                termino = termino.ToLower();
                productos = productos
                    .Where(p => p.Nombre.ToLower().Contains(termino))
                    .ToList();
            }

            return productos;
        }
    }
}