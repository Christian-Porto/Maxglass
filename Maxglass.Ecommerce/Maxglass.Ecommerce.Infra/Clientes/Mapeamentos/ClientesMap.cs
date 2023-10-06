using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;

namespace Maxglass.Ecommerce.Infra.Clientes.Mapeamentos
{
    public class ClientesMap : ClassMap<Cliente>
    {
        public ClientesMap()
        {
            Schema("ecommerce");
            Table("cliente");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Email).Column("email");
            Map(x=>x.Cep).Column("cep");
            Map(x=>x.Senha).Column("passwordhash");
            Map(x=>x.Tipo).Column("tipo").CustomType<StatusClienteEnum>();
            HasManyToMany(x=>x.ProdutosFavoritos).
            Table("favoritaproduto")
            .ParentKeyColumn("idcliente")
            .ChildKeyColumn("idproduto");

        }
    }
}