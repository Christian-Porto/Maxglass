using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Pedidos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Pedidos
{
    [Route("api/web-app/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosAppServico pedidosAppServico;
        private readonly JwtSecurityTokenHandler tokenHandler;

        public PedidosController(IPedidosAppServico pedidosAppServico)
        {
            this.pedidosAppServico = pedidosAppServico;
            this.tokenHandler = new JwtSecurityTokenHandler();   
        }

        [HttpPost]
        public ActionResult<PedidoResponse> Inserir([FromBody] PedidoCadastroRequest pedidoRequest)
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];

            var token = tokenHandler.ReadJwtToken(jwt);

            int codigoCliente = int.Parse(token.Payload.Claims.ToList()[1].Value);

            var pedidos = pedidosAppServico.Inserir(pedidoRequest, codigoCliente);
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoResponse> Recuperar(int id)
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
            var token = tokenHandler.ReadJwtToken(jwt);

            int codigoCliente = int.Parse(token.Payload.Claims.ToList()[1].Value);

            var pedido = pedidosAppServico.Recuperar(id, codigoCliente);
            return Ok(pedido);
        }

        [HttpGet]
        public ActionResult<PaginacaoConsulta<PedidoResponse>> Listar(int pagina, int quantidade)
        {
            
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
            var token = tokenHandler.ReadJwtToken(jwt);

            int codigoCliente = int.Parse(token.Payload.Claims.ToList()[1].Value);
            

            var pedidos = pedidosAppServico.Listar(pagina, quantidade, codigoCliente);
            return Ok(pedidos);
        }
        
        [HttpPut]
        public ActionResult Cancelar(int id)
        {
            var jwt = HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];

            var token = tokenHandler.ReadJwtToken(jwt);

            int codigoCliente = int.Parse(token.Payload.Claims.ToList()[1].Value);

            pedidosAppServico.Cancelar(id, codigoCliente);
            return Ok();
        }

        [HttpGet("RecuperarValor/{id}")]
        public ActionResult<PedidoPagamentoResponse> RecuperarValor(int id)
        {
           var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            return Ok();

        }

    }
}