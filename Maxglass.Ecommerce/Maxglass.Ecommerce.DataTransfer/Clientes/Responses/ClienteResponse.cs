using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Clientes.Responses
{
    public class ClienteResponse
    {
        public string? Email { get; set; }
        public string? Cep { get; protected set; }
    }
}