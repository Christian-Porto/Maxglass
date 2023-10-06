using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;

namespace Maxglass.Ecommerce.Infra.Fretes.Mapeamentos
{
    public class FretesMap : ClassMap<Frete>
    {
         public FretesMap()
        {
            Schema("ecommerce");
            Table("freteregiao");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Regiao).Column("regiao");
            Map(x=>x.Valor).Column("valor");
        }
    }
}