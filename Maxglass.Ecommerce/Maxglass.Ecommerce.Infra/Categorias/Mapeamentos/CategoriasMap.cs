using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;

namespace Maxglass.Ecommerce.Infra.Categorias.Mapeamentos
{
    public class CategoriasMap : ClassMap<Categoria>
    {
        public CategoriasMap()
        {
            Schema("ecommerce");
            Table("categoria");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Descricao).Column("descricao");
        }
    }
}