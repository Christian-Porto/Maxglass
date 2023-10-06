using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Generico.Repositorio;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Repositorio;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.Farois
{
    public class FaroisRepositorio : GenericoRepositorio<Farol>, IFaroisRepositorio
    {
        public FaroisRepositorio(ISession session) : base(session)
        {
            
        }

    }
}