using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.AnosCompatibilidadeVeiculo;

namespace Maxglass.Ecommerce.DataTransfer.Veiculos.Responses
{
    public class VeiculoModeloSemProdutoResponse
    {
        public string? Descricao { get; set; }
        public IList<AnoCompatibilidadeResponse>? AnosCompativeis { get; set; }
    }
}