using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;

namespace Maxglass.Ecommerce.Infra.Pagamentos.Mapeamentos
{
    public class PagamentosMap : ClassMap<Pagamento>
    {
        public PagamentosMap()
        {
            Schema("ecommerce");
            Table("pagamento");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Valor).Column("valor");
            HasMany(x=>x.Pagamentos).KeyColumn("idpagamento").Cascade.All();
            References(x=>x.Pedido).Column("idpedido"); 
        }
        
    }
}