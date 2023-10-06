using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;

namespace Maxglass.Ecommerce.Dominio.Estoques.Entidades
{
    public class EstoqueProduto
    {
        public virtual int Id { get; protected set; }
        public virtual ProdutoBase? Produto { get; protected set; }
        public virtual int? Quantidade { get; protected set; }

        protected EstoqueProduto()
        {
            
        }

        public EstoqueProduto(ProdutoBase? produto, int? quantidade)
        {
            SetProduto(produto);
            SetQuantidade(quantidade);
        }

        public virtual void SetProduto(ProdutoBase? produto)
        {
            if (produto is null)
            {
                throw new Exception("O campo produto não pode ser nulo");
            }
            this.Produto = produto;
        }

        public virtual void SetQuantidade(int? quantidade)
        {
            if (quantidade is null)
            {
                throw new Exception("O campo quantidade não pode ser nulo");
            }
            this.Quantidade = quantidade;
        }
    }
}