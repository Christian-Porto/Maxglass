using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Fretes.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Pedidos.Responses
{
    public class PedidoResponse
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public decimal? Valor { get; set; }
        public int? Situacao { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? ComplementoEndereco { get; set; }
        public DateTime DataPedido { get;  set; }
        public DateTime DataPrevistaEntrega { get;  set; }
        public DateTime DataPrazo { get;  set; }
        public FreteResponse? Frete { get; set; }
        public IList<ItemPedidoResponse>? ItensPedido { get; set; }

        //public ClienteResponse? Cliente { get; set; }
    }
}