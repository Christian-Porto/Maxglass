using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.ProdutosGeral.ProdutoGeral.Entidades
{
    public class ProdutoGeral : ProdutoBase
    
    {
        public virtual string? Aro { get; protected set; }
        public virtual string? Borda { get; protected set; }
        public virtual string? Carcaca { get; protected set; }
        public virtual string? Lente { get; protected set; }
        public virtual SituacaoFarolFrisoEnum Friso { get; protected set; }
        public virtual string? Posicao { get; protected set; }
        public virtual string? Material { get; protected set; }
        public virtual string? MaterialBorracha  { get; protected set; }
        public virtual SituacaoParachoqueAberturaFrisoEnum AberturaFriso { get; protected set; }
        public virtual string? Moldura { get; protected set; }
        public virtual SituacaoParachoqueFuroEscapamentoEnum FuroEscapamento { get; protected set; }
        public virtual SituacaoParachoqueAberturaSpoilerEnum AberturaSpoiler { get; protected set; }    
        public virtual string? Capa { get; protected set; }
        public virtual SituacaoRetrovisorPiscaAlertaEnum PiscaAlerta { get; protected set; }
        public virtual SituacaoRetrovisorSensorPontoCegoEnum SensorPontoCego { get; protected set; }
        public virtual string? Faixa {get; protected set;}

        protected ProdutoGeral()
        {
            
        }

        public ProdutoGeral(
                TipoProdutoBaseEnum tipo, 
                string? nome, 
                decimal altura, 
                decimal profundidade, 
                decimal largura, 
                decimal valor, 
                SituacaoProdutoBaseEnum situacao, 
                IList<Imagem>? imagens, 
                Marca? marca, 
                Categoria? categoria, 
                Equivalencia? chaveEquivalencia, 
                string? aro, 
                string? borda, 
                string? carcaca, 
                string? lente, 
                SituacaoFarolFrisoEnum friso, 
                string? posicao, 
                string? material, 
                string? materialBorracha, 
                SituacaoParachoqueAberturaFrisoEnum aberturaFriso, 
                string? moldura, 
                SituacaoParachoqueFuroEscapamentoEnum furoEscapamento, 
                SituacaoParachoqueAberturaSpoilerEnum aberturaSpoiler, 
                string? capa, 
                SituacaoRetrovisorPiscaAlertaEnum? piscaAlerta, 
                SituacaoRetrovisorSensorPontoCegoEnum? sensorPontoCego, 
                string? faixa) : base(tipo, nome, altura, profundidade,
                 largura, valor, situacao, imagens, marca, categoria,
                 chaveEquivalencia)
        {
            Aro = aro;
            Borda = borda;
            Carcaca = carcaca;
            Lente = lente;
            Friso = friso;
            Posicao = posicao;
            Material = material;
            MaterialBorracha = materialBorracha;
            AberturaFriso = aberturaFriso;
            Moldura = moldura;
            FuroEscapamento = furoEscapamento;
            AberturaSpoiler = aberturaSpoiler;
            Capa = capa;
            PiscaAlerta = piscaAlerta.Value;
            SensorPontoCego = sensorPontoCego.Value;
            Faixa = faixa;
        }
    }
}