using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;

namespace Maxglass.Ecommerce.Infra.Pedidos.Mapeamentos
{
    public class PedidosMap : ClassMap<Pedido>
    {
        public PedidosMap()
        {
            Schema("ecommerce");
            Table("pedido");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Cep).Column("cep");
            Map(x=>x.DataPedido).Column("datapedido");
            Map(x=>x.DataPrevistaEntrega).Column("dataprevistaentrega");
            Map(x=>x.DataPrazo).Column("dataprazo");
            Map(x=>x.Valor).Column("valor");
            Map(x=>x.Situacao).Column("situacao").CustomType<SituacaoPedidoEnum>();
            Map(x=>x.NumeroEndereco).Column("numeroendereco");
            Map(x=>x.ComplementoEndereco).Column("complementoendereco");
            References(x=>x.Frete).Column("idfreteregiao");
            HasMany(x=>x.ItensPedido).KeyColumn("idpedido").Cascade.All();
            References(x=>x.Cliente).Column("idcliente");

        }
    }
}