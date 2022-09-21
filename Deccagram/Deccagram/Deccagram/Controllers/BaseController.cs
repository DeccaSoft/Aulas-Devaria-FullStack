using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Deccagram.Models;
using Deccagram.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deccagram.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly IUsuarioRepository _usuarioRepository; //Mudado de private para protected para poder ser utilizado na UsuarioController

        public BaseController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        protected Usuario LerToken()
        {
            var idUsuario = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault();
            if(string.IsNullOrEmpty(idUsuario))
            {
                return null;
            }
            else
            {
                return _usuarioRepository.GetUsuarioPorId(int.Parse(idUsuario));
            }
        }
    }
}
