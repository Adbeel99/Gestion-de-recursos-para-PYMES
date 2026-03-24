
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class ProductoViewModel
    {
        public Producto Producto { get; set; } = new();
        public IEnumerable<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
    }
}