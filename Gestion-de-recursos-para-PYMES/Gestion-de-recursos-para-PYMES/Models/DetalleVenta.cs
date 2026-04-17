using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class DetalleVenta
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey(nameof(OrdenVenta))]
        public int OrdenId { get; set; }
        public OrdenVenta OrdenVenta { get; set; }

        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}