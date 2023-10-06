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

namespace Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Entidades
{
    public class Palheta : ProdutoBase
    {
        public virtual string? Material { get; protected set; }
        public virtual string? Posicao { get; protected set; }
        public virtual string? MaterialBorracha  { get; protected set; }
        protected Palheta()
        {
            
        }
        public Palheta( 
            string? material, 
            string? posicao, 
            string? materialBorracha,
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
            SetMaterial(material);
            SetPosicao(posicao);
            SetMaterialBorracha(materialBorracha);
        }
        public virtual void SetMaterial(string material)
        {
            if(string.IsNullOrEmpty(material)) throw new Exception ("O material precisa ter um nome.");
            Material = material;
        }
        public virtual void SetPosicao(string posicao)
        {
            if(string.IsNullOrEmpty(posicao)) throw new Exception ("É necessário especificar a posição da palheta.");
            Posicao = posicao;
            
        }
        public virtual void SetMaterialBorracha(string materialBorracha)
        {
            if(string.IsNullOrEmpty(materialBorracha)) throw new Exception ("O material da borracha da palheta precisa ser especificada.");
            MaterialBorracha = materialBorracha;
        }
    
    }
}