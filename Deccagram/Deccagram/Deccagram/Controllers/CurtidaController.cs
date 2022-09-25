using Deccagram.DTOs;
using Deccagram.Models;
using Deccagram.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurtidaController : BaseController
    {
        private readonly ILogger<CurtidaController> _logger;
        private readonly ICurtidaRepository _curtidaRepository;

        public CurtidaController(ILogger<CurtidaController> logger,
            ICurtidaRepository curtidaRepository, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _curtidaRepository = curtidaRepository;
        }

        [HttpPut]
        public IActionResult Curtir([FromBody] CurtidaRequisicaoDTO curtidaDTO)
        {
            try
            {
                if (curtidaDTO != null)
                {
                    Curtida curtida = _curtidaRepository.GetCurtida(curtidaDTO.IdPublicacao, LerToken().Id);
                    if (curtida != null)
                    {
                        _curtidaRepository.Descurtir(curtida);
                        return Ok("Descurtida Realizada com Sucesso!!!");
                    }
                    else
                    {
                        Curtida curtidaNova = new Curtida()
                        {
                            IdPublicacao = curtidaDTO.IdPublicacao,
                            IdUsuario = LerToken().Id
                        };
                        _curtidaRepository.Curtir(curtidaNova);
                        return Ok("Curtida Realizada com Sucesso!!!");
                    }


                }
                else
                {
                    _logger.LogError("A requisição de Curtir está vazia!");
                    return BadRequest("A requisição de Curtir está vazia!");
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Curtir/Descurtir!" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Curtir/Descurtir!!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
