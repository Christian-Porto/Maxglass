using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Responses;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Pedidos.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoResponse>();
            CreateMap<PedidoCadastroRequest, Pedido>();
            CreateMap<Pedido, PedidoCadastroResponse>();
            CreateMap<Pedido, PedidoPagamentoResponse>();
        }
    }
}