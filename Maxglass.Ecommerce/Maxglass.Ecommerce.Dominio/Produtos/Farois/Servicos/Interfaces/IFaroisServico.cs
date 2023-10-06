using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.Farois.Servicos.Interfaces
{
    public interface IFaroisServico
    {
        Farol Validar(int id);
        Farol ValidarAutenticado(Farol farol, Cliente cliente);
    }
}