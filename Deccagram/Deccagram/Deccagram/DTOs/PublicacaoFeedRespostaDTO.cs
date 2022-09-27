using Deccagram.Migrations;
using Deccagram.Models;
using System.Collections.Generic;

namespace Deccagram.DTOs
{
    public class PublicacaoFeedRespostaDTO
    {
        public int IdPublicacao { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int IdUsuario { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<Curtida> Curtidas { get; set; }
        public UsuarioRespostaDTO Usuario { get; set; }
    }
}
