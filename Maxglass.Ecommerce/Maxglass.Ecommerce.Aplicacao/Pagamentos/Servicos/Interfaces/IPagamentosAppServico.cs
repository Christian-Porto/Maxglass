using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Pagamentos.Servicos.Interfaces
{
    public interface IPagamentosAppServico
    {
        PaginacaoConsulta<PagamentoResponse> Listar(int? pagina, int quantidade, PagamentoListarRequest pagamentoRequest, int idCliente);
        PagamentoResponse Recuperar(int id, int idCliente);
        PagamentoInserirResponse PagarPedido(PagamentoInserirRequest pagamentoRequest, int idCliente);
    }
}