using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;

namespace Maxglass.Ecommerce.Infra.Clientes.Mapeamentos
{
    public class ClientesPessoaJuridicaMap : ClassMap<ClientePessoaJuridica>
    {
        public ClientesPessoaJuridicaMap()
        {
            Schema("ecommerce");
            Table("cliente");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Email).Column("email");
            Map(x=>x.Cep).Column("cep");
            Map(x=>x.Senha).Column("passwordhash");
            Map(x=>x.NomeFantasia).Column("nomefantasia");
            Map(x=>x.RazaoSocial).Column("razaosocial");
            Map(x=>x.InscricaoEstadual).Column("ie");
            Map(x=>x.Cnpj).Column("cnpj");
        }
    }
}