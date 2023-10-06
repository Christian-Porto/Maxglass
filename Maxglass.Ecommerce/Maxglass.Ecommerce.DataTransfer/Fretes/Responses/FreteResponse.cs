using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Fretes.Responses
{
    public class FreteResponse
    {
        public int Id { get; set; }
        public string? Regiao { get; set; }
        public decimal Valor { get; set; }
    }
}