using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses
{
    public class EquivalenciaProdutoResponse
    {
        public int Id { get; set; }
        public string? Chave  { get; set; }
        public IList<ProdutoBaseResponse>? Produtos { get; set; }
    }
}