using Deccagram.Models;

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
    }
}
