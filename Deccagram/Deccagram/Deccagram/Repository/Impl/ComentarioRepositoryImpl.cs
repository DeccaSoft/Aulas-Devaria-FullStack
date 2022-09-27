using Deccagram.Models;
using System.Collections.Generic;
using System.Linq;

namespace Deccagram.Repository.Impl
{
    public class ComentarioRepositoryImpl : IComentarioRepository
    {
        private readonly DeccagramContext _context;
        public ComentarioRepositoryImpl(DeccagramContext context)
        {
            _context = context;
        }

        public void Comentar(Comentario comentario)
        {
            _context.Add(comentario);
            _context.SaveChanges();
        }

        public List<Comentario> GetComentarioPorPublicacao(int idPublicacao)
        {
            return _context.Comentarios.Where(c => c.IdPublicacao == idPublicacao).ToList();
        }
    }
}
