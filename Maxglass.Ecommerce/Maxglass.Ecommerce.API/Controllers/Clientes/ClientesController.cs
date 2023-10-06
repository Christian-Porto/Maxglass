using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Aplicacao.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Clientes.Requests;
using Maxglass.Ecommerce.DataTransfer.Clientes.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Maxglass.Ecommerce.API.Controllers.Clientes
{
    [ApiController]
    [Authorize]
    [Route("api/web-app/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAppServico clientesAppServico;

        public ClientesController(IClientesAppServico clientesAppServico)
        {
            this.clientesAppServico = clientesAppServico;
        }
        
        [HttpGet("verificar-cadastro")]
        public ActionResult<bool> VerificarCadastro(){
            var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            var tipoCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "tipo").Value);
           
            return Ok(clientesAppServico.VerificrCadastro(idCliente, tipoCliente));
        }

        [HttpPost("cadastro")]
        public ActionResult CompletarCadastroPessoaFisica(ClientesCadastroCompletoRequest clientesCadastro){
            int idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            var tipoCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "tipo").Value);
            clientesAppServico.CompletarCadastro(idCliente, tipoCliente, clientesCadastro);
            return Ok();
        }

        [HttpGet("produtos/favoritos")]
        public ActionResult<IList<ProdutoBaseResponse>> ListarProdutosFavoritos(){
            int idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

            IList<ProdutoBaseResponse> response = clientesAppServico.RecuperarProdutosFavoritos(idCliente);
            
            return Ok(response);
        }
        
        [HttpPost("produtos/favoritar/{id}")]
        public ActionResult FavoritarProduto(int id){

            int idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            clientesAppServico.FavoritarProduto(idCliente, id);
            return Ok();
        }

        [HttpGet("pj/{codigoPessoaJuridica}")]
        public ActionResult<ClientePessoaJuridicaResponse> RecuperarPessoaJuridica(int codigoPessoaJuridica){
           ClientePessoaJuridicaResponse response = clientesAppServico.RecuperarPessoaJuridica(codigoPessoaJuridica);
           return Ok(response);
        }

        [HttpGet("pf/{codigoPessoaFisica}")]
        public ActionResult<ClientePessoaFisicaResponse> RecuperarPessoaFisica(int codigoPessoaFisica){
           ClientePessoaFisicaResponse response = clientesAppServico.RecuperarPessoaFisica(codigoPessoaFisica);
           return Ok(response);
        }

       [HttpGet("pj")]
        public ActionResult<ClientePessoaJuridicaResponse> RecuperarPessoaJuridica()
        {
            var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            ClientePessoaJuridicaResponse response = clientesAppServico.RecuperarPessoaJuridica(idCliente);
            return Ok(response);
        }

        [HttpGet("pf")]
        public ActionResult<ClientePessoaFisicaResponse> RecuperarPessoaFisica()
        {
            var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            ClientePessoaFisicaResponse response = clientesAppServico.RecuperarPessoaFisica(idCliente);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult EditarPessoa(ClienteGeralRequest clienteEditarRequest)
        {
            var idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            var tipoCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "tipo").Value);

            clientesAppServico.EditarPessoa(clienteEditarRequest, idCliente, tipoCliente);
            return Ok();
        }
    
        [HttpGet("produtos/favoritado/{id}")]
        public ActionResult<bool> VerificarProdutoFavorito(int id){
            int idCliente = int.Parse(this.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

            var response = clientesAppServico.VerificarFavorito(id, idCliente);

            return Ok(response);
        }

    }
}