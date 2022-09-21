using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deccagram.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string FotoPerfil { get; set; } //Criado automaticamente depois na UsuarioController após instanciar uma CosmicService
    }
}
