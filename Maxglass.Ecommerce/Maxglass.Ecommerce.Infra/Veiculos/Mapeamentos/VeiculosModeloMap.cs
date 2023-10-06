using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;

namespace Maxglass.Ecommerce.Infra.Veiculos.Mapeamentos
{
    public class VeiculosModeloMap : ClassMap<VeiculoModelo>
    {
        public VeiculosModeloMap()
        {
            Schema("ecommerce");
            Table("veiculomodelo");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Descricao).Column("descricao");
            References(x=>x.ChaveEquivalencia).Column("idequivalencia");

            HasManyToMany(x=>x.AnosCompativeis)
            .Table("anoveiculo")
            .ParentKeyColumn("idveiculomodelo")
            .ChildKeyColumn("idanocompatibilidade");
        }
    }
}