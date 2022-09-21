using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deccagram.DTOs;
using Deccagram.Models;
using Deccagram.Repository;
using Deccagram.Services;
using Deccagram.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deccagram.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Tira 'controller' da rota e coloca somente o 'Login'
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;  //Utiliza-se Log's para controle de erros
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(ILogger<LoginController> logger, IUsuarioRepository usuarioRepository) //No construtor já se instancia um Objeto de Log
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]          //Usas-se Post para Logins
        [AllowAnonymous]    //API's para Login devem estar abertas
        //Os parâmetros sào passados através de Classes DTO, que são Classses Transacionais, usadas apenas para transacionamento de dados
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDTO loginRequisicao)  //Recebe parâmetros do 'Corpo' da Requisição
        {
            try
            {
                if (!String.IsNullOrEmpty(loginRequisicao.Senha) && !String.IsNullOrEmpty(loginRequisicao.Email)
                     && !String.IsNullOrWhiteSpace(loginRequisicao.Senha) && !String.IsNullOrWhiteSpace(loginRequisicao.Email))
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorLoginSenha(loginRequisicao.Email.ToLower(), MD5Utils.GerarHashMD5(loginRequisicao.Senha));
                    
                    if (usuario != null)
                    {
                        return Ok(new LoginRespostaDTO()
                        {
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            Token = TokenService.CriarToken(usuario)
                        });
                    }
                    else
                    {
                        return BadRequest(new ErrorRespostaDTO()
                        {
                            Descricao = "Login e/ou Senha Inválido(a)!",
                            Status = StatusCodes.Status400BadRequest
                        });
                    }
                }
                else
                {
                    return BadRequest(new ErrorRespostaDTO()
                    {
                        Descricao = "Atenção, Preencha os Campos de Login Corretamente!",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um Erro no Login: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDTO()
                {
                    Descricao = "Ocorreu um Erro ao Fazer Login!",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
