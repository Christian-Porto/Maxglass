using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Veiculos.Servicos.Interfaces
{
    public interface IVeiculosModeloServico
    {
        VeiculoModelo Validar(int id);
    }
}