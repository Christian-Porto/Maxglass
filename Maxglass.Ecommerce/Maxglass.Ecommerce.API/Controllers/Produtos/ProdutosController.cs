using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Produtos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Produtos.Farois.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Palhetas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Parachoques.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Requests;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Retrovisores.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Vidros.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Produtos
{
    [Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosAppServico produtosAppServico;

        private readonly JwtSecurityTokenHandler tokenHandler;


        public ProdutosController(IProdutosAppServico produtosAppServico)
        {
            this.produtosAppServico = produtosAppServico;
            this.tokenHandler = new JwtSecurityTokenHandler();
        }


        [HttpGet]
        public ActionResult<PaginacaoConsulta<ProdutoBaseResponse>> Listar(int pagina, int quantidade, [FromQuery] ProdutoListarRequest produtoListarRequest)
        {

            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var responses = produtosAppServico.Listar(pagina, quantidade, produtoListarRequest, codigoCliente);
            return Ok(responses);
        }

        [HttpGet("farol/{idProduto}")]
        public ActionResult<FarolResponse> RecuperarFarol(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarFarol(idProduto, codigoCliente);
            return Ok(response);
        }

        [HttpGet("vidro/{idProduto}")]
        public ActionResult<VidroResponse> RecuperarVidro(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarVidro(idProduto, codigoCliente);
            return Ok(response);
        }

        [HttpGet("retrovisor/{idProduto}")]
        public ActionResult<RetrovisorResponse> RecuperarRetrovisor(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarRetrovisor(idProduto, codigoCliente);
            return Ok(response);
        }

        [HttpGet("palheta/{idProduto}")]
        public ActionResult<PalhetaResponse> RecuperarPalheta(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarPalheta(idProduto, codigoCliente);
            return Ok(response);
        }

        [HttpGet("parachoque/{idProduto}")]
        public ActionResult<ParachoqueResponse> RecuperarParachoque(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarParachoque(idProduto, codigoCliente);
            return Ok(response);
        }

        [HttpGet("{idProduto}")]
        public ActionResult<ProdutoBaseResponse> Recuperar(int idProduto)
        {
            string codigoClienteString = User.FindFirst("id")?.Value ?? "";
            int codigoCliente = String.IsNullOrEmpty(codigoClienteString) ? 0 : int.Parse(codigoClienteString);

            var response = produtosAppServico.RecuperarProdutoBase(idProduto, codigoCliente);
            return Ok(response);
        }

    }
}