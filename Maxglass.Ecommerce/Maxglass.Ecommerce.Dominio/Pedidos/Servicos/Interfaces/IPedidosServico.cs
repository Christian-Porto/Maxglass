using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosServico
    {
        Pedido Validar(int id);
        Pedido Instanciar(
            string? cep, 
            string? numeroEndereco, 
            string? complementoEndereco
        );

        void Cancelar(Pedido pedido, Cliente cliente);

        Pedido CriarPedido(Pedido pedido, IList<ItemPedido> itemPedidos, Frete frete);

        void MontaPedido(Frete frete, Pedido pedido);
        

    }
}