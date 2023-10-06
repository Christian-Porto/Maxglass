using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Servicos.Interfaces
{
    public interface ITiposPagamentoServico
    {
        TipoPagamento Validar(int id);
    }
}