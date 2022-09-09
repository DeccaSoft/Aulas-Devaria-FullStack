using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deccagram.DTOs;
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

        public LoginController(ILogger<LoginController> logger) //No construtor já se instancia um Objeto de Log
        {
            _logger = logger;
        }

        [HttpPost]          //Usas-se Post para Logins
        [AllowAnonymous]    //API's para Login devem estar abertas
        //Os parâmetros sào passados através de Classes DTO, que são Classses Transacionais, usadas apenas para transacionamento de dados
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDTO loginRequisicao)  //Recebe parâmetros do 'Corpo' da Requisição
        {
            try
            {
                throw new ArgumentException("Erro ao Preencher os Dados");
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
