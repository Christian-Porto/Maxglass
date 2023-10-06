using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;


namespace Maxglass.Ecommerce.DataTransfer.Pedidos.Responses
{
    public class ItemPedidoResponse
    {
        public ProdutoBaseResponse? Produto { get; set; }
        public int? Quantidade { get; set; }
    }
}