using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;

namespace Maxglass.Ecommerce.Dominio.Equivalencias.Servicos.Interfaces
{
    public interface IEquivalenciasServico
    {
        Equivalencia Validar(int id);
    }
}