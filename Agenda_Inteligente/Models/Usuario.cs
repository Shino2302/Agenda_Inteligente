using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Inteligente.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
