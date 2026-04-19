using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Usuario : IdentityUser<int>
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } 

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        public List<MovimientoInventario> MovimientosInventario { get; set; } = new();
        
        public List<OrdenVenta> OrdenesVenta { get; set; } = new();
    }
}