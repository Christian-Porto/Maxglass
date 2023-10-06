using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses
{
    public class TipoPagamentoResponse
    {
        public int Id { get; set; }
        public int? Tipo { get; set; }
        public decimal ValorParcela { get; set; }
        public int Parcela { get; set; }
    }
}