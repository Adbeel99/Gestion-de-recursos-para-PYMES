using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class MovimientoViewModel
    {
        public string Tipo { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public int? ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public List<SelectListItem> Productos { get; set; } = new();
        public List<SelectListItem> Proveedores { get; set; } = new();
    }
}