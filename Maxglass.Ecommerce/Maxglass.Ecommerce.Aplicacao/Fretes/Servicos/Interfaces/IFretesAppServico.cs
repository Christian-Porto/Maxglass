using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Fretes.Requests;
using Maxglass.Ecommerce.DataTransfer.Fretes.Responses;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Fretes.Servicos.Interfaces
{
    public interface IFretesAppServico
    {
        FreteResponse Recuperar(int id);

        PaginacaoConsulta<FreteResponse> Listar(int? pagina, int quantidade, FreteListarRequest freteRequest);
    }
}