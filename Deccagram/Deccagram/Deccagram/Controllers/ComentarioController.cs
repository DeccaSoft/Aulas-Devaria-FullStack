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
    [Route("api/[Controller]")]
    public class ComentarioController : BaseController
    {
        private readonly ILogger<ComentarioController> _logger;
        private readonly IComentarioRepository _comentarioRepository;
        public ComentarioController(ILogger<ComentarioController> logger, IComentarioRepository comentarioRepository, 
            IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _comentarioRepository = comentarioRepository;
        }

        [HttpPut]
        public IActionResult Comentar([FromBody] ComentarioRequisicaoDTO comentarioDTO)
        {
            try
            {
                if (comentarioDTO != null)
                {
                    if (String.IsNullOrEmpty(comentarioDTO.Descricao) || String.IsNullOrWhiteSpace(comentarioDTO.Descricao))
                    {
                        _logger.LogError("Ocorreu um Erro ao Publicar!");
                        return BadRequest("Comentário Deve estar Preenchido!");
                    }
                    Comentario comentario = new Comentario();
                    comentario.Descricao = comentarioDTO.Descricao;
                    comentario.IdPublicacao = comentarioDTO.IdPublicacao;
                    comentario.IdUsuario = LerToken().Id;
                    _comentarioRepository.Comentar(comentario);
                }
                return Ok("Comentário Salvo comSucesso!");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Publicar: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Publicar!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
