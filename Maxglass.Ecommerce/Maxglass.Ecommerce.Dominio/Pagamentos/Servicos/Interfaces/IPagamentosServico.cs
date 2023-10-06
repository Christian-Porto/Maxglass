using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Servicos.Interfaces
{
    public interface IPagamentosServico
    {
        Pagamento Validar(int id);
        Pagamento PagarPedido(Pagamento pagamento, Cliente cliente);
    }
}