using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Clientes.Responses
{
    public class ClientePessoaJuridicaResponse : ClienteResponse
    {
        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? NomeFantasia { get; set; }
    }
}