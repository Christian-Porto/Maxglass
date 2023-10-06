using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;

namespace Maxglass.Ecommerce.Infra.Equivalencias.Mapeamentos
{
    public class EquivalenciasMap : ClassMap<Equivalencia>
    {
        public EquivalenciasMap()
        {
            Schema("ecommerce");
            Table("equivalencia");
            Id(x => x.Id).Column("id");
            Map(x => x.Chave).Column("chave");
            HasMany(p => p.Produtos).KeyColumn("idequivalencia");
            HasMany(v => v.Veiculos).KeyColumn("idequivalencia");
        }

    }
}