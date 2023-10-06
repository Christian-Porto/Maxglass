using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Imagens.Profiles
{
    public class ImagemProfile : Profile
    {
        public ImagemProfile()
        {
            CreateMap<Imagem, ImagemResponse>();
        }
    }
}