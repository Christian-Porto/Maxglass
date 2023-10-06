using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Autenticacoes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Requests;
using Maxglass.Ecommerce.DataTransfer.Autenticacoes.Responses;
using Maxglass.Ecommerce.Dominio.Autenticacoes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Aplicacao.Autenticacoes.Servicos
{
    public class AutenticacoesAppServico : IAutenticacoesAppServico
    {
        private readonly IClientesRepositorio clientesRepositorio;
        private readonly IClientesServico clientesServico;
        private readonly IAutenticacoesServico autenticacoesServico;
        private readonly IMapper mapper;

        public AutenticacoesAppServico(
            IClientesRepositorio clientesRepositorio, 
            IClientesServico clientesServico, 
            IAutenticacoesServico autenticacoesServico,
            IMapper mapper)
        {
            this.clientesRepositorio = clientesRepositorio;
            this.clientesServico = clientesServico;
            this.autenticacoesServico = autenticacoesServico;
            this.mapper = mapper;
        }

        public CadastroResponse Cadastrar(CadastroRequest cadastroRequest)
        {
            var cliente =  autenticacoesServico.ValidarCadastro(cadastroRequest.Email, cadastroRequest.Senha);
            cliente.SetTipo((StatusClienteEnum)cadastroRequest.Tipo);
            cliente.SetSenhaHash(BCrypt.Net.BCrypt.HashPassword(cadastroRequest.Senha));
            cliente = clientesRepositorio.Inserir(cliente);
            var response = mapper.Map<CadastroResponse>(cliente);

            return response;
        }

        public LoginResponse Logar(LoginRequest loginRequest)
        {
            var cliente = clientesRepositorio.RecuperaClientePorEmail(loginRequest.Email);
            cliente = autenticacoesServico.ValidarLogin(cliente, loginRequest.Senha);

            string token = autenticacoesServico.GerarToken(cliente);

            var response = new LoginResponse();
            response.Token = token;

            return response;
        }

        
    }
}