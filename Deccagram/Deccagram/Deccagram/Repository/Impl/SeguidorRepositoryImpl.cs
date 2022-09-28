using Deccagram.Models;
using System;
using System.Linq;

namespace Deccagram.Repository.Impl
{
    public class SeguidorRepositoryImpl : ISeguidorRepository
    {
        private readonly DeccagramContext _context;
        public SeguidorRepositoryImpl(DeccagramContext context)
        {
            _context = context;
        }

        public bool Seguir(Seguidor seguidor)
        {
            try
            {
                _context.Add(seguidor);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DesSeguir(Seguidor seguidor)
        {
            try
            {
                _context.Remove(seguidor);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Seguidor GetSeguidor(int idSeguidor, int idDSeguido)
        {
            return _context.Seguidores.FirstOrDefault(s => s.IdUsuarioSeguidor == idSeguidor && s.IdUsuarioSeguido == idDSeguido);
        }

        public int GetQtdSeguidores(int idUsuario)
        {
            return _context.Seguidores.Count(s => s.IdUsuarioSeguido == idUsuario);
        }

        public int GetQtdSeguindo(int idUsuario)
        {
            return _context.Seguidores.Count(s => s.IdUsuarioSeguidor == idUsuario);
        }
    }
}
