using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Clientes.Requests;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Maxglass.Ecommerce.DataTransfer.Clientes.Responses;
using Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos.Interfaces;
using NHibernate;
using Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos;

namespace Maxglass.Ecommerce.Aplicacao.Clientes.Servicos
{
    public class ClientesAppServico : IClientesAppServico
    {
        private readonly IClientesServico clientesServico;
        private readonly IMapper mapper;
        private readonly IProdutosBaseServico produtosBaseServico;
        private readonly IClientesRepositorio clientesRepositorio;
        private readonly ISession session;
        private readonly IAutenticacoesServico autenticacoesServico;
        private readonly IClientesPessoaJuridicaRepositorio clientesPessoaJuridicaRepositorio;
        private readonly IClientePessoaFisicaRepositorio clientesPessoaFisicaRepositorio;

        public ClientesAppServico(
            IClientesServico clientesServico,
            IMapper mapper,
            IProdutosBaseServico produtosBaseServico,
            IClientesRepositorio clientesRepositorio,
            IAutenticacoesServico autenticacoesServico,
            IClientesPessoaJuridicaRepositorio clientesPessoaJuridicaRepositorio,
            IClientePessoaFisicaRepositorio clientesPessoaFisicaRepositorio)
        {
            this.clientesServico = clientesServico;
            this.mapper = mapper;
            this.produtosBaseServico = produtosBaseServico;
            this.clientesRepositorio = clientesRepositorio;
            this.autenticacoesServico = autenticacoesServico;
            this.clientesPessoaFisicaRepositorio = clientesPessoaFisicaRepositorio;
            this.clientesPessoaJuridicaRepositorio = clientesPessoaJuridicaRepositorio;
        }

        public void CompletarCadastro(int idCliente, int tipoCliente, ClientesCadastroCompletoRequest clientesCadastro)
        {
            switch(tipoCliente){
                case 1:
                    ClientePessoaJuridica clientePJ = clientesServico.ValidarPessoaJuridica(idCliente);
                    clientesServico.CompletarCadastroPessoaJuridica(
                        clientePJ,
                        clientesCadastro.Cnpj,
                        clientesCadastro.RazaoSocial,
                        clientesCadastro.NomeFantasia,
                        clientesCadastro.InscricaoEstadual);
                    break;
                case 2:
                    ClientePessoaFisica clientePF = clientesServico.ValidarPessoaFisica(idCliente);
                     clientesServico.CompletarCadastroPessoaFisica(
                        clientePF, 
                        clientesCadastro.Nome,
                        clientesCadastro.SobreNome, 
                        clientesCadastro.Telefone,
                        clientesCadastro.Cpf);
                    break;
            }
            
            
            
        }

        public void FavoritarProduto(int idCliente, int idProduto)
        {
            Cliente cliente = clientesServico.Validar(idCliente);
            ProdutoBase produto = produtosBaseServico.Validar(idProduto);
            if (cliente.ProdutosFavoritos.Contains(produto))
            {
                cliente.ProdutosFavoritos.Remove(produto);
            }else
            {
                cliente.ProdutosFavoritos.Add(produto);
            } 
            clientesRepositorio.Atualizar(cliente);
        }

        public IList<ProdutoBaseResponse> RecuperarProdutosFavoritos(int idCliente)
        {
            Cliente cliente = clientesServico.Validar(idCliente);
            IList<ProdutoBaseResponse> response = mapper.Map<IList<ProdutoBaseResponse>>(cliente.ProdutosFavoritos);
            return response;
        }

        public bool VerificrCadastro(int id, int tipo)
        {
            switch (tipo){
                case 1:
                    ClientePessoaJuridica clientePJ = clientesServico.ValidarPessoaJuridica(id);  
                    return clientesServico.VerificarCadastroPessoaJuridica(clientePJ);
                case 2:
                    ClientePessoaFisica clientePF = clientesServico.ValidarPessoaFisica(id);
                    return clientesServico.VerificarCadastroPessoaFisica(clientePF);        
            }   
            throw new Exception("tipo do cliente invalido");
        }

        public void EditarPessoa(ClienteGeralRequest clienteEditarRequest, int idCliente, int tipoCliente)
        {
            if (tipoCliente == 1)
            {
                EditarPessoaJuridica(clienteEditarRequest, idCliente);
            }
            if (tipoCliente == 2)
            {
                EditarPessoaFisica(clienteEditarRequest, idCliente);
            }
        }


        public void EditarPessoaFisica(ClienteGeralRequest clienteEditarRequest, int idCliente)
        {
            var transacao = session.BeginTransaction();
            try
            {
                var clienteRetorno = clientesServico.ValidarPessoaFisica(idCliente);
                if (clienteEditarRequest.Nome != null)
                {
                    clienteRetorno.SetNome(clienteEditarRequest.Nome);
                }
                if (clienteEditarRequest.SobreNome != null)
                {
                    clienteRetorno.SetSobreNome(clienteEditarRequest.SobreNome);
                }
                if (clienteEditarRequest.Telefone != null)
                {
                    clienteRetorno.SetTelefone(clienteEditarRequest.Telefone);
                }
                if (clienteEditarRequest.Cpf != null)
                {
                    clienteRetorno.SetCpf(clienteEditarRequest.Cpf);
                }
                if (clienteEditarRequest.Email != null)
                {
                    clienteRetorno.SetEmail(clienteEditarRequest.Email);
                }
                if (clienteEditarRequest.Cep != null)
                {
                    clienteRetorno.SetCep(clienteEditarRequest.Cep);
                }
                var clienteAtualizado = clientesPessoaFisicaRepositorio.Atualizar(clienteRetorno);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public void EditarPessoaJuridica(ClienteGeralRequest clienteEditarRequest, int idCliente)
        {
            var transacao = session.BeginTransaction();
            try
            {
                var clienteRetorno = clientesServico.ValidarPessoaJuridica(idCliente);
                if (clienteEditarRequest.InscricaoEstadual != null)
                {
                    clienteRetorno.SetInscricaoEstadual(clienteEditarRequest.InscricaoEstadual);
                }
                if (clienteEditarRequest.NomeFantasia != null)
                {
                    clienteRetorno.SetNomeFantasia(clienteEditarRequest.NomeFantasia);
                }
                if (clienteEditarRequest.RazaoSocial != null)
                {
                    clienteRetorno.SetRazaoSocial(clienteEditarRequest.RazaoSocial);
                }
                if (clienteEditarRequest.Cnpj != null)
                {
                    clienteRetorno.SetCnpj(clienteEditarRequest.Cnpj);
                }
                if (clienteEditarRequest.Email != null)
                {
                    clienteRetorno.SetEmail(clienteEditarRequest.Email);
                }
                if (clienteEditarRequest.Cep != null)
                {
                    clienteRetorno.SetCep(clienteEditarRequest.Cep);
                }

                var clienteAtualizado = clientesPessoaJuridicaRepositorio.Atualizar(clienteRetorno);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public ClientePessoaFisicaResponse RecuperarPessoaFisica(int idCliente)
        {
            Cliente cliente = clientesServico.ValidarPessoaFisica(idCliente);
            ClientePessoaFisicaResponse response = mapper.Map<ClientePessoaFisicaResponse>(cliente);
            return response;

        }

        public ClientePessoaJuridicaResponse RecuperarPessoaJuridica(int idCliente)
        {
            Cliente cliente = clientesServico.ValidarPessoaJuridica(idCliente);
            ClientePessoaJuridicaResponse response = mapper.Map<ClientePessoaJuridicaResponse>(cliente);
            return response;
        }

        public bool VerificarFavorito(int idProduto, int idCliente)
        {
            Cliente cliente = clientesServico.Validar(idCliente);
            foreach (var item in cliente.ProdutosFavoritos)
            {
                if (item.Id == idProduto){
                    return true;
                }
            } 
            return false;
        }
    
    
    }
}