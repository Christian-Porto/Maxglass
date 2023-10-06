using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Fretes
{
    public class FretesRepositorio : GenericoRepositorio<Frete> ,IFretesRepositorio
    {
        public FretesRepositorio(ISession session) : base(session)
        {
        }

        
    }
}