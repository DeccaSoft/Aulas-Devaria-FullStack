using Microsoft.AspNetCore.Http;

namespace Deccagram.DTOs
{
    public class ImagemDTO
    {
        public string Nome { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
