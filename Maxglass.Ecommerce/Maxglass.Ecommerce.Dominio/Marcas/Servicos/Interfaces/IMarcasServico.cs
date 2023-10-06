using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;

namespace Maxglass.Ecommerce.Dominio.Marcas.Servicos.Interfaces
{
    public interface IMarcasServico
    {
        Marca Validar(int id);
    }
}