using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.Vidros.Servicos.Interfaces
{
    public interface IVidrosServico
    {
        Vidro Validar(int id);

        Vidro ValidarAutenticado(Vidro vidro, Cliente cliente);
    }
}