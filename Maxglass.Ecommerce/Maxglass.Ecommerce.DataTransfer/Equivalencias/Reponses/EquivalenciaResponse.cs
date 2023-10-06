using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses
{
    public class EquivalenciaResponse
    {
        public int Id { get; set; }
        public string? Chave  { get; set; }

        public IList<ProdutoBaseResponse>? Produtos {get; set;}
        public IList<VeiculoModeloResponse>? Veiculos {get; set;}
    }
}