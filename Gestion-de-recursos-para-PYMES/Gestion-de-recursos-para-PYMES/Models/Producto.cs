using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Producto
    {
        [Key]
        public  int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioCosto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }
            public int Existencias { get; set; }

        public string CodigoSKU { get; set; }

        public int ExistenciasMinimas { get; set; }

        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }


    }
}
