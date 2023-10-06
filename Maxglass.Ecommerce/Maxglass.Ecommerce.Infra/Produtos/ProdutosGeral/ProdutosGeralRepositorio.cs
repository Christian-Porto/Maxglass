using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGeral.Repositorios;
using Maxglass.Ecommerce.Dominio.ProdutosGeral.ProdutoGeral.Entidades;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.ProdutosGeral
{
    public class ProdutosGeralRepositorio : GenericoRepositorio<ProdutoGeral>, IProdutosGeralRepositorio
    {
        public ProdutosGeralRepositorio(ISession session) : base(session)
        {
        }
    }
}