using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Usuario : IdentityUser<int>
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;
    }
}