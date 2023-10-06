using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses
{
    public class PagamentoResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public IList<TipoPagamentoResponse> Pagamentos { get; set; }
        public PedidoResponse Pedido { get; set; }

    }
}