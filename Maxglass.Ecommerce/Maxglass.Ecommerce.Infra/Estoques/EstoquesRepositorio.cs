using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;
using Maxglass.Ecommerce.Dominio.Estoques.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Estoques
{
    public class EstoquesRepositorio : GenericoRepositorio<Estoque>, IEstoquesRepositorio
    {
        public EstoquesRepositorio(ISession session) : base(session)
        {
        }
    }
}