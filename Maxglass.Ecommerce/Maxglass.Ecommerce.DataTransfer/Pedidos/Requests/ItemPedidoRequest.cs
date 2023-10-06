using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Pedidos.Requests
{
    public class ItemPedidoRequest
    {
        public int? IdProduto { get; set; }
        public int? Quantidade { get; set; }
        
    }
}