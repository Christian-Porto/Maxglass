using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.AnosCompatibilidade.Entidades;

namespace Maxglass.Ecommerce.Infra.AnosCompatibilidade.Mapeamentos
{
    public class AnosCompatibilidadeMap : ClassMap<AnoCompatibilidade>
    {
        public AnosCompatibilidadeMap()
        {
            Schema("ecommerce");
            Table("anocompatibilidade");
            Id(x => x.Id).Column("id");
            Map(x => x.Ano).Column("ano");
        }
    }
}