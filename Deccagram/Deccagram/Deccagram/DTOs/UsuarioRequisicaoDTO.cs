using Microsoft.AspNetCore.Http;

namespace Deccagram.DTOs
{
    public class UsuarioRequisicaoDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IFormFile FotoPerfil { get; set; }
    }
}
