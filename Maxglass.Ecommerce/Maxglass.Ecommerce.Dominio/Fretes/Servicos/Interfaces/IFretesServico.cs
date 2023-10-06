using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;

namespace Maxglass.Ecommerce.Dominio.Fretes.Servicos.Interfaces
{
    public interface IFretesServico
    {
        Frete Validar(int id);
    }
}