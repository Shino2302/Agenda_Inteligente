using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agenda_Inteligente.Models;

namespace Agenda_Inteligente.Data
{
    public class Agenda_InteligenteContext : DbContext
    {
        public Agenda_InteligenteContext (DbContextOptions<Agenda_InteligenteContext> options)
            : base(options)
        {
        }

        public DbSet<Agenda_Inteligente.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<Agenda_Inteligente.Models.Notas> Notas { get; set; } = default!;
    }
}
