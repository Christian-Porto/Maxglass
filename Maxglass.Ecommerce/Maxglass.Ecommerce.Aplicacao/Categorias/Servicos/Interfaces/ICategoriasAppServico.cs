using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Categorias.Requests;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Categorias.Servicos.Interfaces
{
    public interface ICategoriasAppServico
    {
        CategoriaResponse Recuperar(int id); 
        PaginacaoConsulta<CategoriaResponse> Listar(int? pagina, int quantidade, CategoriaListarRequest categoriaRequest);

    }
}