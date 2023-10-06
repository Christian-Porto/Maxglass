using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Marcas.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Marcas.Requests;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace Maxglass.Ecommerce.API.Controllers.Marcas
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcasAppServico marcasAppServico;

        public MarcasController(IMarcasAppServico marcasAppServico)
        {
            this.marcasAppServico = marcasAppServico;
        }

        [HttpGet("{id}")]
        public ActionResult<MarcaResponse> Recuperar(int id)
        {
            var marca = marcasAppServico.Recuperar(id);
            return Ok(marca);
        }
        [HttpGet]
        public ActionResult<PaginacaoConsulta<MarcaResponse>> Listar(int pagina, int quantidade, [FromQuery] MarcaListarRequest marcaRequest)
        {
            var marcas = marcasAppServico.Listar(pagina, quantidade, marcaRequest);
            return Ok(marcas);
        }
    }
}