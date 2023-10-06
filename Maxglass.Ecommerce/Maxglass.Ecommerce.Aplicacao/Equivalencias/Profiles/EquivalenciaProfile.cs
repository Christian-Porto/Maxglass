using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Equivalencias.Profiles
{
    public class EquivalenciaProfile : Profile
    {
        public EquivalenciaProfile()
        {
            CreateMap<Equivalencia,EquivalenciaResponse>();
            CreateMap<Equivalencia, EquivalenciaProdutoResponse>();
            CreateMap<Equivalencia, EquivalenciaVeiculoResponse>();
        }
    }
}