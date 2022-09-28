using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deccagram.Controllers;
using Deccagram.Models;

namespace Deccagram.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly DeccagramContext _context;
        public UsuarioRepositoryImpl(DeccagramContext context)
        {
            _context = context;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetUsuarioPorLoginSenha(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> GetUsuariosPorNome(string nome)
        {
            return _context.Usuarios.Where(u => u.Nome.Contains(nome)).ToList();
        }

        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public bool VerificarEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email); //Não precisou usar .ToLower, porque já vem minúsculo
        }
    }
}
