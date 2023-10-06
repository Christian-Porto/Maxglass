using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Requests;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Veiculos.Servicos.Interfaces
{
    public interface IVeiculosModeloAppServico
    {
        VeiculoModeloResponse Recuperar (int id);
        PaginacaoConsulta<VeiculoModeloResponse> Listar (int pagina, int quantidade, VeiculoModeloListarRequest veiculoModeloRequest);
    }
}