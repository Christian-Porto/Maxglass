using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Equivalencias.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Equivalencias
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class EquivalenciasController : ControllerBase
    {
        private readonly IEquivalenciasAppServico equivalenciaAppServico;

        public EquivalenciasController(IEquivalenciasAppServico equivalenciaAppServico)
        {
            this.equivalenciaAppServico = equivalenciaAppServico;
        }
        [HttpGet("{id}")]
        public ActionResult<EquivalenciaResponse> Recuperar([FromHeader]int id)
        {
            var response = equivalenciaAppServico.Recuperar(id);
            return Ok(response);
        }
    }
}