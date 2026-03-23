namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string Nombre { get; set; }  

        public string Descripcion { get; set; }
       
        public List<Producto> Productos { get; set; } = new();
    }
}
