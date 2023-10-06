using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests
{
    public class PagamentoInserirRequest
    {
        public decimal Valor{get; set;}
        public IList<TipoPagamentoInserirRequest> Pagamentos {get;set;}
        public int IdPedido {get;set;}
    }
}