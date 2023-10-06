using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Estoques.Requests
{
    public class EstoqueListarRequest
    {
        public string? Cep { get; set; }
        public string? Descricao { get; set; }
    
    }
}