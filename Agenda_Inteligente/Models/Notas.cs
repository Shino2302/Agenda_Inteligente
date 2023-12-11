using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Inteligente.Models
{
    public class Notas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNota { get; set; }
        public string IndexNota { get; set; }
        public string Nota { get; set; }
        public DateTime CreacionDeNota { get; set; }
        public int IdUsuario1 { get; set; }
        [ForeignKey("IdUsuario1")]
        public virtual Usuario Usuario { get; set; }

    }
}
