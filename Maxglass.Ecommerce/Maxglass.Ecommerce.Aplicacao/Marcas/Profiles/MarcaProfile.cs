using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Marcas.Profiles
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<Marca,MarcaResponse>();
        }
    }
}