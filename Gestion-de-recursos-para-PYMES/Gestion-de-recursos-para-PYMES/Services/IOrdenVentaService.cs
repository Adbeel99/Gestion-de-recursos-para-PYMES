using Gestion_de_recursos_para_PYMES.Models;

namespace Gestion_de_recursos_para_PYMES.Services
{
    public interface IOrdenVentaService
    {
        void CrearOrden(OrdenVentaViewModel model, int usuarioId);
        List<OrdenVenta> ObtenerTodas();
        List<OrdenVenta> ObtenerPorUsuario(int usuarioId);
        OrdenVenta ObtenerPorId(int id);
        OrdenVentaViewModel ObtenerOrdenVentaViewModel();
    }
}