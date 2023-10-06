using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Autenticacoes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Requests;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Autenticacoes
{
    [ApiController]
    [Route("api/web-app/[controller]")]
        public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacoesAppServico autenticacoesAppServico;

        public AutenticacaoController(IAutenticacoesAppServico autenticacoesAppServico)
        {
            this.autenticacoesAppServico = autenticacoesAppServico;
        }

        [HttpPost("logar")]
        public ActionResult<LoginResponse> Logar([FromBody]LoginRequest loginRequest)
        {
            
            var response = autenticacoesAppServico.Logar(loginRequest);

            return Ok(response);
        }

         [HttpPost("cadastro")]
         public ActionResult<CadastroResponse> Cadastrar([FromBody]CadastroRequest cadastroRequest)
         {
             var response = autenticacoesAppServico.Cadastrar(cadastroRequest);

             return Ok(response);
         }
    }
}