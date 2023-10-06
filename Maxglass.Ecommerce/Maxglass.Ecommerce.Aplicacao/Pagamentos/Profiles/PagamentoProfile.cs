using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Pagamentos.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<Pagamento, PagamentoResponse>();
            CreateMap<PagamentoInserirRequest, Pagamento>();
            CreateMap<Pagamento, PagamentoInserirResponse>();
            CreateMap<TipoPagamento, TipoPagamentoResponse>();
            CreateMap<TipoPagamentoInserirRequest, TipoPagamento>();
        }
    }
}