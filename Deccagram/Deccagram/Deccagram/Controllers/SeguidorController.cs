using Deccagram.DTOs;
using Deccagram.Models;
using Deccagram.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguidorController : BaseController
    {
        private readonly ILogger<SeguidorController> _logger;
        private readonly ISeguidorRepository _seguidorRepository;

        public SeguidorController(ILogger<SeguidorController> logger, 
            ISeguidorRepository seguidorRepository, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _seguidorRepository = seguidorRepository;
        }

        [HttpPut]
        public IActionResult Seguir(int idSeguido)
        {
            try
            {
                Usuario usuarioSeguido = _usuarioRepository.GetUsuarioPorId(idSeguido);
                Usuario usuarioSeguidor = LerToken();
                if (usuarioSeguido != null)
                {
                    Seguidor seguidor = _seguidorRepository.GetSeguidor(usuarioSeguidor.Id, usuarioSeguido.Id);
                    if (seguidor != null)
                    {
                        _seguidorRepository.DesSeguir(seguidor);
                        return Ok("Desseguindo...");
                    }
                    else
                    {
                        Seguidor seguidorNovo = new Seguidor()
                        {
                            IdUsuarioSeguido = usuarioSeguido.Id,
                            IdUsuarioSeguidor = usuarioSeguidor.Id
                        };
                        _seguidorRepository.Seguir(seguidorNovo);
                        return Ok("Seguindo...");
                    }
                }
                else
                {
                    return BadRequest("Ocorreu um erro ao se tentar Seguir/Desseguir!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Seguir/Desseguir: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Seguir/Desseguir!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
