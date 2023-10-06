using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Produtos.Farois.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Palhetas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Parachoques.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Retrovisores.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Vidros.Responses;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Entidades;
using Maxglass.Ecommerce.Dominio.ProdutosGeral.ProdutoGeral.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Produtos.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Farol, FarolResponse>();
            CreateMap<Palheta, PalhetaResponse>();
            CreateMap<Parachoque, ParachoqueResponse>();
            CreateMap<ProdutoBase, ProdutoBaseResponse>();
            CreateMap<Retrovisor, RetrovisorResponse>();
            CreateMap<Vidro,VidroResponse>();
            CreateMap<ProdutoGeral, ProdutoBaseResponse>();
        }
    }
}