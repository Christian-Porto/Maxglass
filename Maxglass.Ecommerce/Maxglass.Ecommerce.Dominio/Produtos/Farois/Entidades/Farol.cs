using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades
{
    public class Farol : ProdutoBase
    {
    
        public virtual string? Aro { get; protected set; }
        public virtual string? Borda { get; protected set; }
        public virtual string? Carcaca { get; protected set; }
        public virtual string? Lente { get; protected set; }
        public virtual SituacaoFarolFrisoEnum? Friso { get; protected set; }
        public virtual string? Posicao { get; protected set; }
        protected Farol()
        {
        }
        public Farol(
            string? aro, 
            string? borda, 
            string? carcaca, 
            string? lente, 
            SituacaoFarolFrisoEnum? friso, 
            string? posicao, 
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
            SetAro(aro);
            SetBorda(borda);
            SetCarcaca(carcaca);
            SetLente(lente);
            SetFriso(friso);
            SetPosicao(posicao);
        }

        public virtual void SetAro(string? aro)
        {
            if (String.IsNullOrEmpty(aro))
            {
                throw new Exception("O aro não pode ser nulo");
            }
            this.Aro = aro;
        }
        public virtual void SetBorda(string? borda)
        {
            if (String.IsNullOrEmpty(borda))
            {
                throw new Exception("A borda não pode ser nula");
            }
            this.Borda = borda;
        }
        public virtual void SetCarcaca(string? carcaca)
        {
            if (String.IsNullOrEmpty(carcaca))
            {
                throw new Exception("A carcaça não pode ser nula");
            }
            this.Carcaca = carcaca;
        }
        public virtual void SetLente(string? lente)
        {
            if (String.IsNullOrEmpty(lente))
            {
                throw new Exception("A lente não pode ser nula");
            }
            this.Lente = lente;
        }
        public virtual void SetFriso(SituacaoFarolFrisoEnum? friso)
        {
            if (!friso.HasValue)
            {
                throw new Exception("O friso não pode ser nulo");
            }
            this.Friso = friso.Value;
        }

        public virtual void SetPosicao(string? posicao)
        {
            if (String.IsNullOrEmpty(posicao))
            {
                throw new Exception("A posição não pode ser nula");
            }
            this.Posicao = posicao;
        }
       
    }
}

