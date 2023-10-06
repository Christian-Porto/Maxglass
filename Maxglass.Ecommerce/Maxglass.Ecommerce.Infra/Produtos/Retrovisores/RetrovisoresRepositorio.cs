using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.Retrovisores
{
    public class RetrovisoresRepositorio : GenericoRepositorio<Retrovisor>, IRetrovisoresRepositorio
    {
        public RetrovisoresRepositorio(ISession session) : base(session)
        {
            
        }
    }
}