using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.AnosCompatibilidadeVeiculo;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;
using Maxglass.Ecommerce.Dominio.AnosCompatibilidade.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Veiculos.Profiles
{
    public class VeiculoModeloProfile : Profile
    {
        public VeiculoModeloProfile()
        {
            CreateMap<VeiculoModelo, VeiculoModeloResponse>();
            CreateMap<VeiculoModelo, VeiculoModeloSemProdutoResponse>();
            CreateMap<AnoCompatibilidade, AnoCompatibilidadeResponse>();
        }
    }
}