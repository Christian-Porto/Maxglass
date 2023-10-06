using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Pedidos.Servicos.Interfaces
{
    public interface IPedidosAppServico
    {
        PaginacaoConsulta<PedidoResponse> Listar(int? pagina, int quantidade, int codigoCliente);
        PedidoResponse Recuperar(int codigo, int codigoCliente);
        PedidoCadastroResponse Inserir(PedidoCadastroRequest request, int codigoCliente);
        void Cancelar(int codigo, int codigoCliente);
        PedidoPagamentoResponse RecuperarValor(int codigo, int codigoCliente);
        
    }
}