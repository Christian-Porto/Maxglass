using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Generico.Repositorio;

namespace Maxglass.Ecommerce.Dominio.Clientes.Repositorios
{
    public interface IClientesRepositorio : IGenericoRepositorio<Cliente>
    {
        Cliente RecuperaClientePorEmail(string email);
    }
}