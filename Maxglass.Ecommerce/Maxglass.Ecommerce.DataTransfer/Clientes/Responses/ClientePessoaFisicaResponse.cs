using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Clientes.Responses
{
    public class ClientePessoaFisicaResponse : ClienteResponse
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }

    }
}