using Maxglass.Ecommerce.Aplicacao.Veiculos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Requests;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Veiculos
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class VeiculosModeloController : ControllerBase
    {
        private readonly IVeiculosModeloAppServico veiculoModeloAppServico;
        public VeiculosModeloController(IVeiculosModeloAppServico veiculoModeloAppServico )
        {
            this.veiculoModeloAppServico = veiculoModeloAppServico;
        }

        [HttpGet("{id}")]
        public ActionResult<VeiculoModeloResponse> Recuperar(int id)
        {
            var response = veiculoModeloAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<PaginacaoConsulta<VeiculoModeloResponse>> Listar(int pagina, int quantidade, [FromQuery] VeiculoModeloListarRequest veiculoModeloRequest)
        {
            var veiculo = veiculoModeloAppServico.Listar(pagina, quantidade, veiculoModeloRequest);
            return Ok(veiculo);
        }
    }
}