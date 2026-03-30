using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public interface IMovimientoRepository
    {
        void CrearMovimiento(MovimientoInventario movimiento);
        void ActualizarProducto(Producto producto);
        List<MovimientoInventario> ObtenerTodos();
        List<MovimientoInventario> ObtenerPorProducto(int productoId);
    }
}