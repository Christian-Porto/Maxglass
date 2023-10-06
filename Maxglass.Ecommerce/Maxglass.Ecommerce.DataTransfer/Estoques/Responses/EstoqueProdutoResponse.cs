using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;


namespace Maxglass.Ecommerce.DataTransfer.Estoques.Responses
{
    public class EstoqueProdutoResponse
    {
        public int Id { get; set; }
        public ProdutoBaseResponse? Produto { get; set; }
        public int? Quantidade { get; set; }
    }
}