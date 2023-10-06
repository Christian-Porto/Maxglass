using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses;

namespace Maxglass.Ecommerce.Aplicacao.Equivalencias.Servicos.Interfaces
{
    public interface IEquivalenciasAppServico
    {
        EquivalenciaResponse Recuperar(int id); 
        
    }
}