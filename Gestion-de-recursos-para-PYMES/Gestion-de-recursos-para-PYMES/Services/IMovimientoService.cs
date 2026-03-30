using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface IMovimientoService
    {
        void RegistrarMovimiento(MovimientoViewModel model, int usuarioId);
        List<MovimientoInventario> ObtenerTodos();
        List<MovimientoInventario> ObtenerPorProducto(int productoId);
        MovimientoViewModel ObtenerMovimientoViewModel();
    }
}