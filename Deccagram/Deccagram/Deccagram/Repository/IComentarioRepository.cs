using Deccagram.Models;
using System.Collections.Generic;

namespace Deccagram.Repository
{
    public interface IComentarioRepository
    {
        public void Comentar(Comentario comentario);
        List<Comentario> GetComentarioPorPublicacao(int idPublicacao);
    }
}
