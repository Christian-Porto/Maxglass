using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses
{
    public class EquivalenciaVeiculoResponse
    {
        public IList<VeiculoModeloSemProdutoResponse>? Veiculos {get; set;}
    }
}