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
    }
}
