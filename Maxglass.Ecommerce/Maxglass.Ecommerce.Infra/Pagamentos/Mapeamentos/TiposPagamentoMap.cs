using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Enumeradores;

namespace Maxglass.Ecommerce.Infra.Pagamentos.Mapeamentos
{
    public class TiposPagamentoMap : ClassMap<TipoPagamento>
    {
        public TiposPagamentoMap()
        {
            Schema("ecommerce");
            Table("tipopagamento");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Parcela).Column("parcela");
            Map(x=>x.ValorParcela).Column("valor");
            Map(x=>x.Tipo).Column("tipo").CustomType<TiposPagamentoEnum>();
        }
    }
}