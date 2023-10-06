using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Categorias.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Categorias
{
    public class CategoriasRepositorio : GenericoRepositorio<Categoria>, ICategoriasRepositorio 
    {
        public CategoriasRepositorio(ISession session) : base(session)
        {
            
        }
    }
}