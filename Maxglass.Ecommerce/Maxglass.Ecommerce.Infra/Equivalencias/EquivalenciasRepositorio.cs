using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Equivalencias
{
    public class EquivalenciasRepositorio : GenericoRepositorio<Equivalencia>, IEquivalenciasRepositorio
    {
        public EquivalenciasRepositorio(ISession session) : base(session)
        {
        }
    }
}