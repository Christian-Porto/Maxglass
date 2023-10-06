using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Generico.Repositorio;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Pagamentos
{
    public class TiposPagamentoRepositorio : GenericoRepositorio<TipoPagamento>, ITiposPagamentoRepositorio
    {
        public TiposPagamentoRepositorio(ISession session) : base(session)
        {
            
        }       
    }
}