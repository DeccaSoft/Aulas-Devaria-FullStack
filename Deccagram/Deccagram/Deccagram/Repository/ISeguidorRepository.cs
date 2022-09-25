using Deccagram.Models;

namespace Deccagram.Repository
{
    public interface ISeguidorRepository
    {
        public bool Seguir(Seguidor seguidor);
        public bool DesSeguir(Seguidor seguidor);
        public Seguidor GetSeguidor(int idSeguidor, int idDSeguido);
    }
}
