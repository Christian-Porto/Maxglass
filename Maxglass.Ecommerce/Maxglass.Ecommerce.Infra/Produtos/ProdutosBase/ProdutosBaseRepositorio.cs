using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.ProdutosBase
{
    public class ProdutosBaseRepositorio : GenericoRepositorio<ProdutoBase>, IProdutosBaseRepositorio
    {
        public ProdutosBaseRepositorio(ISession session) : base(session)
        {

        }
    }
}