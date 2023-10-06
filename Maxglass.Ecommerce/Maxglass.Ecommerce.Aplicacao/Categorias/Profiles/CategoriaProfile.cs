using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Categorias.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponse>();
        }
    }
}