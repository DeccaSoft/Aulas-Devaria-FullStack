using Deccagram.Models;

namespace Deccagram.Repository.Impl
{
    public class PublicacaoRepositoryImpl : IPublicacaoRepository
    {
        private readonly DeccagramContext _context;
        public PublicacaoRepositoryImpl(DeccagramContext context)
        {
            _context = context;
        }

        public void Publicar(Publicacao publicacao)
        {
            _context.Add(publicacao);
            _context.SaveChanges();
        }
    }
}
