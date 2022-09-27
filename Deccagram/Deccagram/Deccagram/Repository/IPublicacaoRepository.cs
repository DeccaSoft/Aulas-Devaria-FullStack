using Deccagram.DTOs;
using Deccagram.Models;
using System.Collections.Generic;

namespace Deccagram.Repository
{
    public interface IPublicacaoRepository
    {
        public void Publicar(Publicacao publicacao);
        List<PublicacaoFeedRespostaDTO> GetPublicacoesFeed(int idUsuario);
        List<PublicacaoFeedRespostaDTO> GetPublicacoesFeedUsuario(int idUsuario);
    }
}
