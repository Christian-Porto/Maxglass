using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;

namespace Maxglass.Ecommerce.Infra.Marcas.Mapeamentos
{
    public class MarcasMap : ClassMap<Marca>
    {
        public MarcasMap()
        {
            Schema("ecommerce");
            Table("marca");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Nome).Column("nome");
        }
    }
}