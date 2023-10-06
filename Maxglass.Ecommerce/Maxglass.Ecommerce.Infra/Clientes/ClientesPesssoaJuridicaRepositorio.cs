using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Clientes
{
    public class ClientesPessoaJuridicaRepositorio : GenericoRepositorio<ClientePessoaJuridica>, IClientesPessoaJuridicaRepositorio
    {
        public ClientesPessoaJuridicaRepositorio(ISession session) : base(session)
        {
            
        }

    }
}