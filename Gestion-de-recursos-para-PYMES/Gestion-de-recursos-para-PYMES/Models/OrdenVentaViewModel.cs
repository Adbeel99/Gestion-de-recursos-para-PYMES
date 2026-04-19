using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class OrdenVentaViewModel
    {
        public int ClienteId { get; set; }
        public List<DetalleVentaViewModel> Detalles { get; set; } = new();
        public List<SelectListItem> Clientes { get; set; } = new();
        public List<SelectListItem> Productos { get; set; } = new();
    }

    public class DetalleVentaViewModel
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}