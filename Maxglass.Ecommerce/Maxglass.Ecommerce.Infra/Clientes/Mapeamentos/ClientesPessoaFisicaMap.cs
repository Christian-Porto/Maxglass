using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;

namespace Maxglass.Ecommerce.Infra.Clientes.Mapeamentos
{
    public class ClientesPessoaFisicaMap : ClassMap<ClientePessoaFisica>
    {
        public ClientesPessoaFisicaMap()
        {
            Schema("ecommerce");
            Table("cliente");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Email).Column("email");
            Map(x=>x.Cep).Column("cep");
            Map(x=>x.Senha).Column("passwordhash");
            Map(x=>x.Nome).Column("nome");
            Map(x=>x.SobreNome).Column("sobrenome");
            Map(x=>x.Cpf).Column("cpf");
            Map(x=>x.Telefone).Column("telefone");
        }
    }
}