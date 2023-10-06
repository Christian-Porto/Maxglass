using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Estoques.Repositorios;
using Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Repositorios;
using Maxglass.Ecommerce.Dominio.Fretes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;
using Maxglass.Ecommerce.Dominio.Pedidos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Servicos
{
    public class PedidosServico : IPedidosServico
    {
        private readonly IPedidosRepositorio pedidosRepositorio;
        private readonly IEstoquesServico estoquesServico;
        private readonly IItensPedidoServico itensPedidoServico;

        public PedidosServico(IPedidosRepositorio pedidosRepositorio, IEstoquesServico estoquesServico, IItensPedidoServico itensPedidoServico)
        {
            this.pedidosRepositorio = pedidosRepositorio;
            this.estoquesServico = estoquesServico;
            this.itensPedidoServico = itensPedidoServico;
        }

        public Pedido Instanciar(string? cep, string? numeroEndereco, string? complementoEndereco)
        {
            var pedido = new Pedido(cep, numeroEndereco, complementoEndereco);
            return pedido;
        }

        public Pedido Validar(int id)
        {
            var pedido = pedidosRepositorio.Recuperar(id);
            if (pedido is null)
            {
                throw new Exception("Esse pedido não existe");
            }

            return pedido;
        }

        public void Cancelar(Pedido pedido, Cliente cliente)
        {
            if(pedido.Cliente.Id != cliente.Id)
            {
                throw new Exception("Cliente inválido");
            }

            if (!(pedido.Situacao == SituacaoPedidoEnum.AguardandoPagamento))
            {
                throw new Exception("Esse pedido não pode ser cancelado");
            }         
            
             pedido.SetSituacao(SituacaoPedidoEnum.Cancelado);

             foreach (var item in pedido.ItensPedido)
             {
                estoquesServico.IncrementaUnidadeEstoque(item.Quantidade.Value, item.Produto.Id);
             }

             pedidosRepositorio.Atualizar(pedido);            
            
        }

        public Pedido CriarPedido(Pedido pedido, IList<ItemPedido> itemPedidos, Frete frete)
        {
                 foreach (var item in itemPedidos)
                 {
                     itensPedidoServico.DecrementaUnidadeNoEstoque(item.Quantidade.Value, item.Produto.Id);               
                 }
                 pedido.SetListaItensPedido(itemPedidos);
                 MontaPedido(frete, pedido);
                 pedido = pedidosRepositorio.Inserir(pedido);

                 return pedido;
        }

         public virtual void MontaPedido(Frete frete, Pedido pedido)
        {
            pedido.SetSituacao(SituacaoPedidoEnum.AguardandoPagamento);
            pedido.SetFrete(frete);
            pedido.SetDataPedido();
            pedido.SetDataPrevistaEntrega();
            pedido.SetValorBrutoSemFrete();
            pedido.SetValor();
            pedido.SetDataPrazo();
        }

    }
}