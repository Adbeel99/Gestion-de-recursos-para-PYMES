using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_de_recursos_para_PYMES.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(200)]
        public string Empresa { get; set; }

        [EmailAddress, StringLength(200)]
        public string Email { get; set; }

        [Phone, StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(300)]
        public string Direccion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}