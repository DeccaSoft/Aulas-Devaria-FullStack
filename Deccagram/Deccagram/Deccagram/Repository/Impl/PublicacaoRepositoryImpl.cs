using Deccagram.DTOs;
using Deccagram.Models;
using System.Collections.Generic;
using System.Linq;

namespace Deccagram.Repository.Impl
{
    public class PublicacaoRepositoryImpl : IPublicacaoRepository
    {
        private readonly DeccagramContext _context;
        public PublicacaoRepositoryImpl(DeccagramContext context)
        {
            _context = context;
        }

        public List<PublicacaoFeedRespostaDTO> GetPublicacoesFeed(int idUsuario)
        {
            var feed =
                from publicacoes in _context.Publicacoes //Erro: CS1936
                join seguidores in _context.Seguidores on publicacoes.IdUsuario equals seguidores.IdUsuarioSeguido
                where seguidores.IdUsuarioSeguidor == idUsuario
                select new PublicacaoFeedRespostaDTO
                {
                    IdPublicacao = publicacoes.Id,
                    Descricao = publicacoes.Descricao,
                    Foto = publicacoes.Foto,
                    IdUsuario = publicacoes.IdUsuario
                };
            return feed.ToList();
        }

        public void Publicar(Publicacao publicacao)
        {
            _context.Add(publicacao);
            _context.SaveChanges();
        }

        public List<PublicacaoFeedRespostaDTO> GetPublicacoesFeedUsuario(int idUsuario)
        {
            var feedUsuario =
                from publicacoes in _context.Publicacoes //Erro: CS1936
                where publicacoes.IdUsuario == idUsuario
                select new PublicacaoFeedRespostaDTO
                {
                    IdPublicacao = publicacoes.Id,
                    Descricao = publicacoes.Descricao,
                    Foto = publicacoes.Foto,
                    IdUsuario = publicacoes.IdUsuario
                };
            return feedUsuario.ToList();
        }

        public int GetQtdPublicacoes(int idUsuario)
        {
            return _context.Publicacoes.Count(p => p.IdUsuario == idUsuario);
        }
    }
}
