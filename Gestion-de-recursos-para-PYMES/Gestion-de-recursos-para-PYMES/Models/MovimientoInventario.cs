using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class MovimientoInventario
    {
        [Key]
        public int MovimientoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public string Tipo { get; set; } 

        public string Observaciones { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey(nameof(Proveedor))]
        public int? ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public List<DetalleMovimiento> Detalles { get; set; } = new();
    }
}