using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Estoques.Requests;
using Maxglass.Ecommerce.DataTransfer.Estoques.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Maxglass.Ecommerce.API.Controllers.Estoques
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class EstoquesController : ControllerBase
    {
        private readonly IEstoquesAppServico estoquesAppServico;

        public EstoquesController(IEstoquesAppServico estoquesAppServico)
        {
            this.estoquesAppServico = estoquesAppServico;
        }

        [HttpGet("{id}")]
        public ActionResult<EstoqueResponse> Recuperar(int id)
        {
            var response = estoquesAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<PaginacaoConsulta<EstoqueResponse>> Listar(int pagina, int quantidade, [FromQuery] EstoqueListarRequest estoqueRequest)
        {
            var response = estoquesAppServico.Listar(pagina, quantidade, estoqueRequest);
            return Ok(response);
        }
        [HttpGet("quantidade/{codigoProduto}")]
        public ActionResult<EstoqueQuantidadeResponse> RecuperarQuantidadeProduto(int codigoProduto)
        {
            var response = estoquesAppServico.RecuperarQuantidadeProduto(codigoProduto);
            return Ok(response);
        }
    }
}