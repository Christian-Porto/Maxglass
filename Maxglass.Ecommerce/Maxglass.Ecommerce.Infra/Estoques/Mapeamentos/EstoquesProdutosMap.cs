using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;

namespace Maxglass.Ecommerce.Infra.Estoques.Mapeamentos
{
    public class EstoquesProdutosMap : ClassMap<EstoqueProduto>
    {
        public EstoquesProdutosMap()
        {
            Schema("ecommerce");
            Table("estoqueproduto");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Quantidade).Column("quantidade");
            References(x=>x.Produto).Column("idproduto");
        }
    }
}