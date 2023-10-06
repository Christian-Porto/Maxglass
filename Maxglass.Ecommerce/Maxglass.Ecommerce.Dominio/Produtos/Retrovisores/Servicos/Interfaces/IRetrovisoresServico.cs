using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Servicos.Interfaces
{
    public interface IRetrovisoresServico
    {
        Retrovisor Validar(int id);

        Retrovisor ValidarAutenticado(Retrovisor retrovisor, Cliente cliente);
    }
}