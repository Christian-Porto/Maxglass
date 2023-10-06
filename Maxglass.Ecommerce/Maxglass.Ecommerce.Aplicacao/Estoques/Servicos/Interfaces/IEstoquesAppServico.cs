using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Estoques.Requests;
using Maxglass.Ecommerce.DataTransfer.Estoques.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Estoques.Servicos.Interfaces
{
    public interface IEstoquesAppServico
    {
        EstoqueResponse Recuperar(int id);
        EstoqueQuantidadeResponse RecuperarQuantidadeProduto(int codigoProduto);
        PaginacaoConsulta<EstoqueResponse> Listar(int? pagina, int quantidade, EstoqueListarRequest estoqueRequest);
    }
}