using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;

namespace Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces
{
    public interface IProdutosGenericoServico<T>
    {
        T ValidarAutenticado(T produto, Cliente cliente);

        T RetornaProdutoComValorAtacado(T produto);
        IList<T> RetornaProdutoComValorAtacado(IList<T> produtos, Cliente cliente);
    }
}