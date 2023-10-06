using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Clientes.Requests;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Maxglass.Ecommerce.DataTransfer.Clientes.Responses;

namespace Maxglass.Ecommerce.Aplicacao.Clientes.Servicos.Interfaces
{
    public interface IClientesAppServico
    {
        bool VerificrCadastro(int id, int tipo);
        void CompletarCadastro(int idCliente, int tipoCliente, ClientesCadastroCompletoRequest clientesCadastro);
        IList<ProdutoBaseResponse> RecuperarProdutosFavoritos(int idCliente); 
        void FavoritarProduto(int idCliente, int idproduto);
       ClientePessoaJuridicaResponse RecuperarPessoaJuridica(int codigo);
       ClientePessoaFisicaResponse RecuperarPessoaFisica(int codigo);
       public void EditarPessoaFisica(ClienteGeralRequest clienteEditarRequest, int idCliente);
       public void EditarPessoaJuridica(ClienteGeralRequest clienteEditarRequest, int idCliente);
       bool VerificarFavorito(int idProduto, int idCliente);
    
       void EditarPessoa(ClienteGeralRequest clienteEditarRequest, int idCliente, int tipoCliente);
       
    }

}