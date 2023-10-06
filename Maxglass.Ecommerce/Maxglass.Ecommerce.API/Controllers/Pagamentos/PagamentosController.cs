using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Pagamentos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Pagamentos
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    [Authorize]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentosAppServico pagamentosAppServico;

        public PagamentosController(IPagamentosAppServico pagamentosAppServico)
        {
            this.pagamentosAppServico = pagamentosAppServico;
        }

        [HttpPost("pagamento")]
        public ActionResult<PagamentoInserirResponse> PagarPedido(PagamentoInserirRequest pagamentoRequest)
        {
            var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            
            var response = pagamentosAppServico.PagarPedido(pagamentoRequest, idCliente);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<PagamentoResponse> Recuperar(int id)
        {
             var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

            var pagamento = pagamentosAppServico.Recuperar(id, idCliente); 
            return Ok(pagamento);
        }

        [HttpGet]
        public ActionResult<PaginacaoConsulta<PagamentoResponse>> Listar (int pagina, int quantidade, [FromQuery]PagamentoListarRequest pagamentoRequest)
        {
             var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

            var pagamentos = pagamentosAppServico.Listar(pagina, quantidade, pagamentoRequest, idCliente);
            return Ok(pagamentos);
        }
    }
}