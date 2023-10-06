using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces
{
    public interface IEstoquesServico
    {
        Estoque Validar(int id);

        void IncrementaUnidadeEstoque(int quantidade, int idItem);
        void DecrementaUnidadeNoEstoque(int quantidade, int idItem);
    }
}