using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IItensPedidoServico
    {
        ItemPedido Validar(int id);
        ItemPedido Inserir(ItemPedido itemPedido);
        ItemPedido Instanciar(int idProduto, int quantidade, Pedido pedido); 
       
        void IncrementaUnidadeEstoque(int quantidade, int idItem);

        void DecrementaUnidadeNoEstoque(int quantidade, int idItem);
    }
}