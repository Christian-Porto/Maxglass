using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Veiculos
{
    public class VeiculosModeloRepositorio : GenericoRepositorio<VeiculoModelo>, IVeiculoModeloRepositorio
    {
        public VeiculosModeloRepositorio(ISession session) : base(session)
        {
        }
    }
}