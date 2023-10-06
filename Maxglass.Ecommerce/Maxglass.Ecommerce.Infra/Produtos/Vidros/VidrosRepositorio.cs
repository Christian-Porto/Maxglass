using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.Vidros
{
    public class VidrosRepositorio : GenericoRepositorio<Vidro>, IVidrosRepositorio
    {
        public VidrosRepositorio (ISession session) : base(session)
        {

        }
    }
}