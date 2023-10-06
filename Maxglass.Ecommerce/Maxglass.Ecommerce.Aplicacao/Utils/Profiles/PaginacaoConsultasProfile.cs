using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Utils.Profiles
{
    public class PaginacaoConsultasProfile : Profile
    {

        public PaginacaoConsultasProfile()
        {
            CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
        }
        
    }
}