using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Enumeradores;
using Maxglass.Ecommerce.Dominio.ProdutosGeral.ProdutoGeral.Entidades;

namespace Maxglass.Ecommerce.Infra.Produtos.ProdutosGeral.Mapeamentos
{
    public class ProdutosGeralMap : ClassMap<ProdutoGeral>
    {
        public ProdutosGeralMap()
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
            HasManyToMany(x=>x.Imagens)
            .Table("imagemproduto")
            .ParentKeyColumn("idproduto")
            .ChildKeyColumn("idimagem");
            References(x=>x.ChaveEquivalencia).Column("idequivalencia");
            References(x=>x.Marca).Column("idmarca ");
            References(x=>x.Categoria).Column("idcategoria");


            Map(x => x.Aro).Column("aro");
            Map(x => x.Borda).Column("borda");
            Map(x => x.Carcaca).Column("carcaca");
            Map(x => x.Friso).Column("friso").CustomType<SituacaoFarolFrisoEnum>();
            Map(x => x.Lente).Column("lente");
            Map(x => x.Posicao).Column("posicao");
            Map(x=>x.Material).Column("materialpalheta");
            Map(x=>x.MaterialBorracha).Column("materialborracha");
            Map(x => x.AberturaFriso).Column("aberturafriso").CustomType<SituacaoParachoqueAberturaFrisoEnum>();
            Map(x => x.Moldura).Column("moldura");
            Map(x => x.FuroEscapamento).Column("furoescapamento").CustomType<SituacaoParachoqueFuroEscapamentoEnum>();
            Map(x => x.AberturaSpoiler).Column("aberturaspoiler").CustomType<SituacaoParachoqueAberturaSpoilerEnum>();
            Map(x=>x.Capa).Column("capa");
            Map(x=>x.PiscaAlerta).Column("piscaalerta").CustomType<SituacaoRetrovisorPiscaAlertaEnum>();
            Map(x=>x.SensorPontoCego).Column("sensorpontocego").CustomType<SituacaoRetrovisorSensorPontoCegoEnum>();
            Map(x=>x.Faixa).Column("faixa");
        }
    }
}