using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Estoques.Requests
{
    public class EstoqueProdutoListarRequest
    {
        public int? Produto { get; set; }
        public int? Quantidade { get; set; }
    }
}