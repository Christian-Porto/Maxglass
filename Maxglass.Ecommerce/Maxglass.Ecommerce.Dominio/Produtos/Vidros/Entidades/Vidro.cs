using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Produtos.Vidros.Entidades
{
    public class Vidro : ProdutoBase
    {
        public virtual string? Faixa {get; protected set;}
        public virtual string? Posicao {get; protected set;}

        public Vidro(
            string? faixa, 
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
 
            SetFaixa(faixa);
            SetPosicao(posicao);
 
        }
        protected Vidro()
        {
            
        }
    

        public virtual void SetFaixa(string faixa)
        {
            if(string.IsNullOrEmpty(faixa)) throw new Exception ("O campo precisa ser especificado.");
            Faixa = faixa;
        }
        public virtual void SetPosicao(string posicao)
        {
            if(string.IsNullOrEmpty(posicao)) throw new Exception ("O campo precisa ser especificado.");
            Posicao = posicao;
        }
    
    }
}