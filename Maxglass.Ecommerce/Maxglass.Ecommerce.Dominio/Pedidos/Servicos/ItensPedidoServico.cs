using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;
using Maxglass.Ecommerce.Dominio.Pedidos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Servicos
{
    public class ItensPedidoServico : IItensPedidoServico
    {
        private readonly IItensPedidoRepositorio itensPedidoRepositorio;
        private readonly IProdutosBaseServico produtosBaseServico;
        private readonly IEstoquesServico estoquesServico;

        

        public ItensPedidoServico(IItensPedidoRepositorio itensPedidoRepositorio, IProdutosBaseServico produtosBaseServico, IEstoquesServico estoquesServico)
        {
            this.itensPedidoRepositorio = itensPedidoRepositorio;
            this.produtosBaseServico = produtosBaseServico;
            this.estoquesServico = estoquesServico;
        }


        public ItemPedido Inserir(ItemPedido itemPedido)
        {
            itensPedidoRepositorio.Inserir(itemPedido);
            return itemPedido;
        }

        public ItemPedido Instanciar(int idProduto, int quantidade, Pedido pedido)
        {   
            var produto = produtosBaseServico.Validar(idProduto);
            produto.SetValorAreaProduto();
           
            var itemPedido = new ItemPedido(quantidade, produto, pedido);

            return itemPedido;

        }


        public ItemPedido Validar(int id)
        {
            var itemPedido = itensPedidoRepositorio.Recuperar(id);
            if(itemPedido == null)
            {
                throw new Exception("Esse item não existe");
            }
            return itemPedido;
        }

          public void DecrementaUnidadeNoEstoque(int quantidade, int idItem)
        {
            estoquesServico.DecrementaUnidadeNoEstoque(quantidade, idItem);
        }

        public void IncrementaUnidadeEstoque(int quantidade, int idItem)
        {
            estoquesServico.IncrementaUnidadeEstoque(quantidade, idItem);
        }

        
    }
}