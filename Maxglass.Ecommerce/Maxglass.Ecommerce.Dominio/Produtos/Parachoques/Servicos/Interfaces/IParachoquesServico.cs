using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Servicos.Interfaces
{
    public interface IParachoquesServico
    {
        Parachoque Validar(int id);
        Parachoque ValidarAutenticado(Parachoque parachoque, Cliente cliente);

    }
}