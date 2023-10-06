using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests
{
    public class TipoPagamentoListarRequest
    {
        public int? Tipo { get; set; }
        public decimal? ValorParcela { get; set; }
        public int? Parcela { get; set; }
    }
}