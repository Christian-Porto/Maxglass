using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;

namespace Maxglass.Ecommerce.Infra.Imagens.Mapeamentos
{
    public class ImagensMap : ClassMap<Imagem>
    {
        public ImagensMap()
        {
            Schema("ecommerce");
            Table("imagem");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Url).Column("url");
        }
    }
}