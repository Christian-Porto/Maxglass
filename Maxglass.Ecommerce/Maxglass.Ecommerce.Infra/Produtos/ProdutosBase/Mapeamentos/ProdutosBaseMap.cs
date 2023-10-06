using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;

namespace Maxglass.Ecommerce.Infra.Produtos.ProdutosBase.Mapeamentos
{
    public class ProdutosBaseMap : ClassMap<ProdutoBase>
    {
        public ProdutosBaseMap()
        {
            Schema("ecommerce");
            Table("produto");
            Id(x=>x.Id).Column("id");
            Map(x=> x.Tipo).Column("tipo").CustomType<TipoProdutoBaseEnum>();;
            Map(x=>x.Nome).Column("nome");
            Map(x=>x.Altura).Column("altura");
            Map(x=>x.Largura).Column("largura");
            Map(x=>x.Profundidade).Column("profundidade");
            Map(x=>x.Valor).Column("valor");
            Map(x=>x.Situacao).Column("situacao").CustomType<SituacaoProdutoBaseEnum>();
            References(x=>x.ChaveEquivalencia).Column("idequivalencia");
            References(x=>x.Marca).Column("idmarca ");
            References(x=>x.Categoria).Column("idcategoria");
            
            HasManyToMany(x=>x.Imagens)
            .Table("imagemproduto")
            .ParentKeyColumn("idproduto")
            .ChildKeyColumn("idimagem");
        }
    }
}