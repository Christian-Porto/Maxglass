using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Imagens.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Repositorios;
using Maxglass.Ecommerce.Dominio.Imagens.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Aplicacao.Imagens.Servicos
{
    public class ImagensAppServico : IImagensAppServico
    {
        private readonly IMapper mapper;
        private readonly IImagensServico imagensServico;
        private readonly IImagensRepositorio imagensRepositorio;

        public ImagensAppServico(IMapper mapper ,IImagensServico imagensServico, IImagensRepositorio imagensRepositorio)
        {
            this.mapper = mapper;
            this.imagensServico = imagensServico;
            this.imagensRepositorio = imagensRepositorio;
        }

        public ImagemResponse Recuperar(int id)
        {
            var imagem = imagensServico.Validar(id);
            ImagemResponse response = mapper.Map<ImagemResponse>(imagem);
            return response;
        }
    }
}