using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Marcas.Requests;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Marcas.Servicos.Interfaces
{
    public interface IMarcasAppServico
    {
        MarcaResponse Recuperar(int id);
        PaginacaoConsulta<MarcaResponse> Listar(int? pagina, int quantidade, MarcaListarRequest marcaRequest);
    }
}