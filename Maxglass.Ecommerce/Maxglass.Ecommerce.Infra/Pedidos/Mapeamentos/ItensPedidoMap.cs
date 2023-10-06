using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Infra.Pedidos.Mapeamentos
{
    public class ItensPedidoMap : ClassMap<ItemPedido>
    {
        public ItensPedidoMap()
        {
            Schema("ecommerce");
            Table("itempedido");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Quantidade).Column("quantidade");
            References(x=>x.Produto).Column("idproduto");
            References(x=>x.Pedido).Column("idpedido");
        }
    }
}