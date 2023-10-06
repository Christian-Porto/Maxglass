using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Responses;
using Maxglass.Ecommerce.DataTransfer.Clientes.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Clientes.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, CadastroResponse>();
            CreateMap<Cliente, ClientePessoaFisica>();
            CreateMap<Cliente, ClientePessoaJuridica>();
            CreateMap<ClientePessoaFisica, ClientePessoaFisicaResponse>();
            CreateMap<ClientePessoaJuridica, ClientePessoaJuridicaResponse>();
        }
    }
}