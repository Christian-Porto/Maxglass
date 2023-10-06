using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Pedidos.Requests
{
    public class PedidoCadastroRequest
    {
        public string? Cep { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? ComplementoEndereco { get; set; }
        public int? IdFrete { get; set; }
        public IList<ItemPedidoRequest> itemPedidoRequest { get; set; }
    }
}