using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;

namespace Maxglass.Ecommerce.Infra.Estoques.Mapeamentos
{
    public class EstoquesMap : ClassMap<Estoque>
    {
        public EstoquesMap()
        {
            Schema("ecommerce");
            Table("estoque");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Cep).Column("cep");
            Map(x=>x.Descricao).Column("descricao");
            HasMany(x=>x.EstoqueProduto).KeyColumn("idestoque");
        }
    }
}