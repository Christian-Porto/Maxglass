using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Estoques.Responses
{
    public class EstoqueResponse
    {
        public int Id { get; set; }
        public string? Cep { get; set; }
        public string? Descricao { get; set; }
        public IList<EstoqueProdutoResponse>? EstoqueProduto { get; set; }
    }
}