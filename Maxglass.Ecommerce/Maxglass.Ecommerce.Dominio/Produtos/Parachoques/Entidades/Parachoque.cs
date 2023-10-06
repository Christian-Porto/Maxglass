using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Entidades
{
    public class Parachoque : ProdutoBase
    {
        public virtual string? Posicao { get; protected set; }
        public virtual SituacaoParachoqueAberturaFrisoEnum? AberturaFriso { get; protected set; }
        public virtual string? Moldura { get; protected set; }
        public virtual SituacaoParachoqueFuroEscapamentoEnum? FuroEscapamento { get; protected set; }
        public virtual SituacaoParachoqueAberturaSpoilerEnum? AberturaSpoiler { get; protected set; }

        public Parachoque()
        {
        }

        public Parachoque(
            string? posicao, 
            SituacaoParachoqueAberturaFrisoEnum? aberturaFriso, 
            string? moldura, 
            SituacaoParachoqueFuroEscapamentoEnum? furoEscapamento, 
            SituacaoParachoqueAberturaSpoilerEnum? aberturaSpoiler,
            TipoProdutoBaseEnum tipo,
            string? nome, 
            decimal altura, 
            decimal profundidade, 
            decimal largura, 
            decimal valor, 
            SituacaoProdutoBaseEnum status,
            IList<Imagem>? imagens, 
            Marca? marca, 
            Categoria? categoria, 
            Equivalencia? chaveEquivalencia) : base(
                tipo, 
                nome, 
                altura, 
                profundidade, 
                largura, 
                valor, 
                status, 
                imagens, 
                marca, 
                categoria,
                chaveEquivalencia) 
        {
            SetPosicao(posicao);
            SetAberturaFriso(aberturaFriso);
            SetMoldura(moldura);
            SetFuroEscapamento(furoEscapamento);
            SetAberturaFriso(aberturaFriso);
        }

        public virtual void SetPosicao(string? posicao)
        {
            if (String.IsNullOrEmpty(posicao))
            {
                throw new Exception("O campo posição não pode ser nulo");
            }
            this.Posicao = posicao;
        }

        public virtual void SetAberturaFriso(SituacaoParachoqueAberturaFrisoEnum? aberturaFriso)
        {
            if (aberturaFriso == null)
            {
                throw new Exception("O campo abertura do friso não pode ser nulo");
            }
            this.AberturaFriso = aberturaFriso;
        }

        public virtual void SetMoldura(string? moldura)
        {
            if (String.IsNullOrEmpty(moldura))
            {
                throw new Exception("O campo moldura não pode ser nulo");
            }
            this.Moldura = moldura;
        }
        
        public virtual void SetFuroEscapamento(SituacaoParachoqueFuroEscapamentoEnum? furoEscapamento)
        {
            if (furoEscapamento == null)
            {
                throw new Exception("O campo furo escapamento não pode ser nulo");
            }
            this.FuroEscapamento = furoEscapamento;
        }

        public virtual void SetAberturaSpoiler(SituacaoParachoqueAberturaSpoilerEnum? aberturaSpoiler)
        {
            if (aberturaSpoiler == null)
            {
                throw new Exception("O campo abertura spoiler não pode ser nulo");
            }
            this.AberturaSpoiler = aberturaSpoiler;
        }

    }
}