using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Repositories
{
    public interface IOrdenVentaRepository
    {
        void CrearOrden(OrdenVenta orden);
        void ActualizarProducto(Producto producto);
        List<OrdenVenta> ObtenerTodas();
        List<OrdenVenta> ObtenerPorUsuario(int usuarioId);
        OrdenVenta ObtenerPorId(int id);
    }
}