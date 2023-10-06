using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.Parachoques
{
    public class ParachoquesRepositorio : GenericoRepositorio<Parachoque>, IParachoquesRepositorio
    {
        public ParachoquesRepositorio(ISession session) : base(session)
        {
            
        }
    }
}