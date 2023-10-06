using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Fretes.Responses;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Fretes.Profiles
{
    public class FreteProfile : Profile
    {
        public FreteProfile()
        {
            CreateMap<Frete, FreteResponse>();
        }
    }
}