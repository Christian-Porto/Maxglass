using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Maxglass.Ecommerce.Infra.Clientes
{
    public class ClientesRepositorio : GenericoRepositorio<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(ISession session) : base(session)
        {
        }

        public Cliente RecuperaClientePorEmail(string email)
        {
            Cliente cliente =  session.Query<Cliente>().Where(cliente => cliente.Email == email).FirstOrDefault();
            return cliente;
        }
    }
}