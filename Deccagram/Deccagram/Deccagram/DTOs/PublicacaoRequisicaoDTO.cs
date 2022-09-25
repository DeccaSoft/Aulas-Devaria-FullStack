using Microsoft.AspNetCore.Http;

namespace Deccagram.DTOs
{
    public class PublicacaoRequisicaoDTO
    {
        public string Descricao { get; set; }
        public IFormFile Foto { get; set; }
    }
}
