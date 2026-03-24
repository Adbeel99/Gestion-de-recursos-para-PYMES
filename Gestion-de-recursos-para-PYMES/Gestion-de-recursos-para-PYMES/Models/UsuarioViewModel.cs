namespace Gestion_de_recursos_para_PYMES.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string RolActual { get; set; }
    }

    public class CambiarRolViewModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string RolActual { get; set; }
        public string NuevoRol { get; set; }
    }
}