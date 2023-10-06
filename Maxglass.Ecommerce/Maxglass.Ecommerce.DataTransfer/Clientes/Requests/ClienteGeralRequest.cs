using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Clientes.Requests
{
    public class ClienteGeralRequest
    {
        public string? Cep { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? NomeFantasia { get; set; }
    }
}