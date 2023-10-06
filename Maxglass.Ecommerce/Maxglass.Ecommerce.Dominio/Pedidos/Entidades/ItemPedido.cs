using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Entidades
{
    public class ItemPedido
    {
        public virtual int Id { get; protected set; }
        public virtual int? Quantidade { get; protected set; }
        public virtual ProdutoBase? Produto { get; protected set; }
        public virtual Pedido? Pedido { get; protected set; }
        public virtual decimal? ValorItemPedido { get; protected set; }

        protected ItemPedido()
        {
        }

        public ItemPedido(int? quantidade, ProdutoBase? produto, Pedido? pedido)
        {
            SetQuantidade(quantidade);
            SetProdutoBase(produto);
            SetPedido(pedido);
            SetValorItemPedido();
        }
        public virtual void SetValorItemPedido()
        {
            decimal valorItemPedido = this.Produto.Valor * this.Quantidade.Value;
            if(valorItemPedido <= 0){
                throw new Exception("Valor não pode ser menor ou igual a zero");
            }
            this.ValorItemPedido = valorItemPedido;
        }

        public virtual void SetQuantidade(int? quantidade)
        {
            if (quantidade.Value <= 0)
            {
                throw new Exception("Item pedido precisa ter quantidade de produto");
            }

            this.Quantidade = quantidade.Value;
        }

        public virtual void SetProdutoBase(ProdutoBase? produto)
        {
            if (produto is null)
            {
                throw new Exception("Item pedido precisa ter produto");
            }

            this.Produto = produto;
        }

        public virtual void SetPedido(Pedido? pedido)
        {
            if (pedido is null)
            {
                throw new Exception("Item pedido precisa estar associado a um pedido");
            }

            this.Pedido = pedido;
        }

    }
}