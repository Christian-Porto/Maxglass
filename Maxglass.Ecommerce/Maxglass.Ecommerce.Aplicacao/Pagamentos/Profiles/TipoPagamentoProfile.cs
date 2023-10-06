using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Pagamentos.Profiles
{
    public class TipoPagamentoProfile : Profile
    {
        public TipoPagamentoProfile()
        {
            CreateMap<TipoPagamento, TipoPagamentoResponse>();
        }
    }
}