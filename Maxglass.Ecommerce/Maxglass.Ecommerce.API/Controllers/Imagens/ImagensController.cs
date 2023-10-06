using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Imagens.Servicos;
using Maxglass.Ecommerce.Aplicacao.Imagens.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxglass.Ecommerce.API.Controllers.Imagens
{
    [ApiController]
    [Route("api/web-app/[controller]")]
    public class ImagensController : ControllerBase
    {
        private readonly IImagensAppServico imagensAppServico;

        public ImagensController(IImagensAppServico imagensAppServico)
        {
            this.imagensAppServico = imagensAppServico;
        }
        
        [HttpGet("{id}")]
        public ActionResult<ImagemResponse> Recuperar(int id)
        {
            var imagens = imagensAppServico.Recuperar(id);
            return Ok(imagens);
        }
    }
}