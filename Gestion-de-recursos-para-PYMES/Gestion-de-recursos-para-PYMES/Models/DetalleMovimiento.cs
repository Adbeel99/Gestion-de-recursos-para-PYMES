using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class DetalleMovimiento
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey(nameof(MovimientoInventario))]
        public int MovimientoId { get; set; }
        public MovimientoInventario MovimientoInventario { get; set; }

        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}