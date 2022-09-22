using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deccagram.DTOs;
using Deccagram.Models;
using Deccagram.Repository;
using Deccagram.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController //Alterado de ControllerBase para BaseController para Authorize Geral
    {
        public readonly ILogger<UsuarioController> _logger;
        //public readonly IUsuarioRepository _usuarioRepository; //Agora o UsuarioRepository já existe na BaseController

        public UsuarioController(ILogger<UsuarioController> logger, 
            IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            //_usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        //[Authorize]   //Não precisa mais, pois já está herdado do BaseController
        public IActionResult ObterUsuario()
        {
            try
            {
                Usuario usuario = LerToken();
                return Ok(new UsuarioRespostaDTO
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Obter Usuário!");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO() 
                {
                    Descricao = "Ocorreu o Seguinte Erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPut]
        public IActionResult AtualizarUsuario([FromForm] UsuarioRequisicaoDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = LerToken();
                if (usuarioDTO != null)
                {
                    var erros = new List<string>();
                    if (string.IsNullOrEmpty(usuarioDTO.Nome) || string.IsNullOrWhiteSpace(usuarioDTO.Nome))
                    {
                        erros.Add("Nome Inválido!");
                    }

                    if (erros.Count > 0)
                    {
                        return BadRequest(new ErrorRespostaDTO()
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Erros = erros
                        });
                    }
                    else
                    {
                        CosmicService cosmicService = new CosmicService();
                        usuario.FotoPerfil = cosmicService.EnviarImagem(new ImagemDTO{ Imagem = usuarioDTO.FotoPerfil, Nome = usuarioDTO.Nome.Replace(" ", "") });
                        usuario.Nome = usuarioDTO.Nome;
                        _usuarioRepository.AtualizarUsuario(usuario);
                    }
                }
                return Ok("Usuário atualizado com Sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Salvar Usuário!");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu o Seguinte Erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalvarUsuario([FromForm] UsuarioRequisicaoDTO usuarioDTO)  //Alterado de FromBody para FromForm
        {
            try
            {

                if (usuarioDTO != null)
                {
                    var erros = new List<string>();
                    if (string.IsNullOrEmpty(usuarioDTO.Nome) || string.IsNullOrWhiteSpace(usuarioDTO.Nome))
                    {
                        erros.Add("Nome Inválido!");
                    }
                    if (string.IsNullOrEmpty(usuarioDTO.Email) || string.IsNullOrWhiteSpace(usuarioDTO.Email) 
                        || !usuarioDTO.Email.Contains("@") || !usuarioDTO.Email.Contains("."))
                    {
                        erros.Add("E-Mail Inválido!");
                    }
                    if (string.IsNullOrEmpty(usuarioDTO.Senha) || string.IsNullOrWhiteSpace(usuarioDTO.Senha))
                    {
                        erros.Add("Senha Inválida!");
                    }
                    if(erros.Count > 0)
                    {
                        return BadRequest(new ErrorRespostaDTO()
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Erros = erros
                        });
                    }

                    CosmicService cosmicService = new CosmicService();
                    Usuario usuario = new Usuario()
                    {
                        Email = usuarioDTO.Email,
                        Senha = usuarioDTO.Senha,
                        Nome = usuarioDTO.Nome,
                        FotoPerfil = cosmicService.EnviarImagem(new ImagemDTO { Imagem = usuarioDTO.FotoPerfil, Nome = usuarioDTO.Nome.Replace(" ", "")})
                    };


                    usuario.Senha = Utils.MD5Utils.GerarHashMD5(usuario.Senha);
                    usuario.Email = usuario.Email.ToLower();
                    if (!_usuarioRepository.VerificarEmail(usuario.Email))
                    {
                        _usuarioRepository.Salvar(usuario);
                    }
                    else
                    {
                        return BadRequest(new ErrorRespostaDTO()
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Descricao = "E-Mail já Cadastrado!"
                        });
                    }
                    
                }
                return Ok("Usuário salvo com Sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro ao Salvar Usuário!");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu o Seguinte Erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
