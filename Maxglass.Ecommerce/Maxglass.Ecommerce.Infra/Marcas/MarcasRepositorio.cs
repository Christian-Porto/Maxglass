using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Marcas
{
    public class MarcasRepositorio : GenericoRepositorio<Marca>, IMarcasRepositorio
    {
        public MarcasRepositorio(ISession session) : base(session)
        {
        }
    }
}