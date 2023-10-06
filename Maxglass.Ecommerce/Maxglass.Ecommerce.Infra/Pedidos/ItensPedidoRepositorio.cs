using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Pedidos
{
    public class ItensPedidoRepositorio : GenericoRepositorio<ItemPedido>, IItensPedidoRepositorio
    {
        public ItensPedidoRepositorio(ISession session) : base(session)
        {
        }
    }
}