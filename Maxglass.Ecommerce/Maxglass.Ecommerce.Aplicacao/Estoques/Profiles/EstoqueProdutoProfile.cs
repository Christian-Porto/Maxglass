using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Estoques.Responses;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Estoques.Profiles
{
    public class EstoqueProdutoProfile : Profile
    {
       public EstoqueProdutoProfile()
       {
            CreateMap<EstoqueProduto, EstoqueProdutoResponse>();
       }
    }
}