using Deccagram.DTOs;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Deccagram.Services
{
    public class CosmicService
    {
        public string EnviarImagem(ImagemDTO imagemDTO)
        {
            Stream imagem = imagemDTO.Imagem.OpenReadStream(); //Transforma a imagem em uma Stream
            var client = new HttpClient(); //Utilizado para se consumir uma HTTP API
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "7uz3lMwIM5EYpfa5eWSB9WS9SUrr5XsZL2pTjJn5aZLfvV8oAa");
            //Montando o Body do Tipo FormData
            var request = new HttpRequestMessage(HttpMethod.Post, "file");
            var conteudo = new MultipartFormDataContent
            {
                {new StreamContent(imagem), "media", imagemDTO.Nome }
            };
            request.Content = conteudo;
            var retornoReq = client.PostAsync("https://upload.cosmicjs.com/v2/buckets/deccagram2-production/media", request.Content).Result;
            var urlRetorno = retornoReq.Content.ReadFromJsonAsync<CosmicRespostaDTO>(); //Lê o retorno Json Tipando como CosmicRespostaDTO
            
            return urlRetorno.Result.media.url;
        }
    }
}
