using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Produtos.Palhetas
{
    public class PalhetasRepositorio: GenericoRepositorio<Palheta>, IPalhetasRepositorio
    {
        
        public PalhetasRepositorio (ISession session) : base(session)
        {

        }
    }
}