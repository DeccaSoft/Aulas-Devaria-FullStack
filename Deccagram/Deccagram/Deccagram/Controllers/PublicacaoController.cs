using Deccagram.DTOs;
using Deccagram.Migrations;
using Deccagram.Models;
using Deccagram.Repository;
using Deccagram.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicacaoController : BaseController
    {
        private readonly ILogger<PublicacaoController> _logger;
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly IComentarioRepository _comentarioRepository;
        private readonly ICurtidaRepository _curtidaRepository;

        public PublicacaoController(ILogger<PublicacaoController> logger,
            IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository, 
            IComentarioRepository comentarioRepository, ICurtidaRepository curtidaRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _publicacaoRepository = publicacaoRepository;
            _comentarioRepository = comentarioRepository;
            _curtidaRepository = curtidaRepository;
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

        [HttpGet]
        [Route("feed")]
        public IActionResult FeedHome()
        {
            try
            {
                List<PublicacaoFeedRespostaDTO> feed = _publicacaoRepository.GetPublicacoesFeed(LerToken().Id);

                foreach (PublicacaoFeedRespostaDTO feedResposta in feed)
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorId(feedResposta.IdUsuario);
                    UsuarioRespostaDTO usuarioRespostaDTO = new UsuarioRespostaDTO()
                    {
                        Nome = usuario.Nome,
                        Avatar = usuario.FotoPerfil,
                        IdUsuario = usuario.Id
                    };
                    feedResposta.Usuario = usuarioRespostaDTO;
                    //Não precisa fazer DTO para comentário
                    List<Comentario> comentarios = _comentarioRepository.GetComentarioPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Comentarios = comentarios;

                    List<Curtida> curtidas = _curtidaRepository.GetCurtidaPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Curtidas = curtidas;
                }
                return Ok(feed);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Carregar o Feed da Home!" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Carregar o Feed da Home!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpGet]
        [Route("feedusuario")]
        public IActionResult FeedUsuario(int idUsuario)
        {
            try
            {
                List<PublicacaoFeedRespostaDTO> feed = _publicacaoRepository.GetPublicacoesFeedUsuario(idUsuario);

                foreach (PublicacaoFeedRespostaDTO feedResposta in feed)
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorId(feedResposta.IdUsuario);
                    UsuarioRespostaDTO usuarioRespostaDTO = new UsuarioRespostaDTO()
                    {
                        Nome = usuario.Nome,
                        Avatar = usuario.FotoPerfil,
                        IdUsuario = usuario.Id
                    };
                    feedResposta.Usuario = usuarioRespostaDTO;
                    List<Comentario> comentarios = _comentarioRepository.GetComentarioPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Comentarios = comentarios;

                    List<Curtida> curtidas = _curtidaRepository.GetCurtidaPorPublicacao(feedResposta.IdPublicacao);
                    feedResposta.Curtidas = curtidas;
                }
                return Ok(feed);
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Carregar o Feed do Usuário!" + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Carregar o Feed do Usuário!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
