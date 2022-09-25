using Deccagram.DTOs;
using Deccagram.Models;
using Deccagram.Repository;
using Deccagram.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : BaseController
    {
        private readonly ILogger<PublicacaoController> _logger;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(ILogger<PublicacaoController> logger,
            IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
        }

        [HttpPost]
        public IActionResult Publicar([FromForm] PublicacaoRequisicaoDTO publicacaoDTO)
        {
            try
            {
                Usuario usuario = LerToken();
                CosmicService cosmicService = new CosmicService();
                if (publicacaoDTO != null)
                {
                    if (String.IsNullOrEmpty(publicacaoDTO.Descricao) || String.IsNullOrWhiteSpace(publicacaoDTO.Descricao))
                    {
                        _logger.LogError("Descrição Inválida!");
                        return BadRequest("A Publicação DEVE ter uma Descrição!");
                    }
                    if(publicacaoDTO.Foto == null)
                    {
                        _logger.LogError("Foto Inválida!");
                        return BadRequest("A Publicação DEVE ter uma Foto!");
                    }
                    Publicacao publicacao = new Publicacao()
                    {
                        Descricao = publicacaoDTO.Descricao,
                        IdUsuario = usuario.Id,
                        Foto = cosmicService.EnviarImagem(new ImagemDTO { Imagem = publicacaoDTO.Foto, Nome = "publicacao" })
                    };
                    _publicacaoRepository.Publicar(publicacao);
                }
                return Ok("Publicação Salva com Sucesso!!!");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Publicar: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro na Publicação!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
