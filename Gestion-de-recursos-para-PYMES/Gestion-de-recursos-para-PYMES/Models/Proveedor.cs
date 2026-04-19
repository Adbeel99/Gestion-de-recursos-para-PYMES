using System.ComponentModel.DataAnnotations;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Descripcion { get; set; }

        public List<MovimientoInventario> MovimientosInventario { get; set; } = new();
    }
}