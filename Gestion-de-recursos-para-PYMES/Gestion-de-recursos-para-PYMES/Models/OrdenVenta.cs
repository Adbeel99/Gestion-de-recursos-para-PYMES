using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class OrdenVenta
    {
        [Key]
        public int OrdenId { get; set; }

        [Required]
        public string Estado { get; set; } = "Pendiente";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Cliente))]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<DetalleVenta> Detalles { get; set; } = new();
    }
}