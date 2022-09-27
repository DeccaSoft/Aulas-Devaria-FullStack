using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Deccagram.Models
{
    public class DeccagramContext : DbContext
    {
        public DeccagramContext(DbContextOptions<DeccagramContext> option) : base(option)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Seguidor> Seguidores { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        

    }
}
