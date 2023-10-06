using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Fretes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Fretes.Requests;
using Maxglass.Ecommerce.DataTransfer.Fretes.Responses;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Fretes
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class FretesController : ControllerBase
    {
        private readonly IFretesAppServico fretesAppServico;
    

        public FretesController(IFretesAppServico fretesAppServico)
        {
            this.fretesAppServico = fretesAppServico;
        }
        [HttpGet("{id}")]
        public ActionResult<FreteResponse> Recuperar(int id)
        {
            var response = fretesAppServico.Recuperar(id);
            return Ok(response);
        }
        
        [HttpGet]
        public ActionResult<PaginacaoConsulta<FreteResponse>> Listar( int pagina, int quantidade, [FromQuery]FreteListarRequest freteRequest)
        {
            var response = fretesAppServico.Listar(pagina, quantidade, freteRequest);
            return Ok(response);
        }
    }
}