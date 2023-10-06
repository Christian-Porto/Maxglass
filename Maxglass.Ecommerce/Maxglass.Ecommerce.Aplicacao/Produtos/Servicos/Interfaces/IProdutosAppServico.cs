using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Produtos.Farois.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Requests;
using Maxglass.Ecommerce.DataTransfer.Produtos.Palhetas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Parachoques.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Retrovisores.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Vidros.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        PaginacaoConsulta<ProdutoBaseResponse> Listar(int? pagina, int quantidade, ProdutoListarRequest ProdutoListarRequest, int? codigoCliente);

        FarolResponse RecuperarFarol(int idProduto, int? codigoCliente);

        PalhetaResponse RecuperarPalheta(int idProduto, int? codigoCliente);

        ParachoqueResponse RecuperarParachoque(int idProduto, int? codigoCliente);

        RetrovisorResponse RecuperarRetrovisor(int idProduto, int? codigoCliente);

        ProdutoBaseResponse RecuperarProdutoBase(int idProduto, int? codigoCliente);

        VidroResponse RecuperarVidro(int idProduto, int? codigoCliente);


    }
}