using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.AnosCompatibilidadeVeiculo;
using Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses;

namespace Maxglass.Ecommerce.DataTransfer.Veiculos.Responses
{
    public class VeiculoModeloResponse
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public EquivalenciaProdutoResponse? ChaveEquivalencia { get; set; }
        public IList<AnoCompatibilidadeResponse>? AnosCompativeis { get; set; }
    }
}