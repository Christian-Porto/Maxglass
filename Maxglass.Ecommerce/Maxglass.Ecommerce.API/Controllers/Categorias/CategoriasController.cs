using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Categorias.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Categorias.Requests;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace Maxglass.Ecommerce.API.Controllers.Categorias
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppServico categoriasAppServico;
        public CategoriasController(ICategoriasAppServico categoriasAppServico)
        {
            this.categoriasAppServico = categoriasAppServico;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaResponse> Recuperar(int id)
        {
            var categoria = categoriasAppServico.Recuperar(id);
            return Ok(categoria); 
        }

        [HttpGet]
        public ActionResult<PaginacaoConsulta<CategoriaResponse>> Listar(int pagina, int quantidade,[FromQuery] CategoriaListarRequest categoriaRequest)
        {
            var categoria = categoriasAppServico.Listar(pagina, quantidade, categoriaRequest); 
            return Ok(categoria); 
        }
        
    }
}