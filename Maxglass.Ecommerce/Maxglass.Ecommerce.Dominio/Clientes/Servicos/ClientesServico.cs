using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Clientes.Servicos
{
    public class ClientesServico : IClientesServico
    {
        private readonly IClientesRepositorio clientesRepositorio;
        private readonly IClientePessoaFisicaRepositorio clientesPessoaFisicaRepositorio;
        private readonly IClientesPessoaJuridicaRepositorio clientesPessoaJuridicaRepositorio;

        public ClientesServico(
            IClientesRepositorio clientesRepositorio,
            IClientePessoaFisicaRepositorio clientesPessoaFisicaRepositorio,
            IClientesPessoaJuridicaRepositorio clientesPessoaJuridicaRepositorio)
        {
            this.clientesRepositorio = clientesRepositorio;
            this.clientesPessoaFisicaRepositorio = clientesPessoaFisicaRepositorio;
            this.clientesPessoaJuridicaRepositorio = clientesPessoaJuridicaRepositorio;
        }

        public void CompletarCadastroPessoaFisica(ClientePessoaFisica cliente, string nome, string sobrenome, string telefone, string cpf)
        {
            cliente.SetNome(nome);
            cliente.SetSobreNome(sobrenome);
            cliente.SetTelefone(telefone);
            cliente.SetCpf(cpf);
            clientesPessoaFisicaRepositorio.Atualizar(cliente);
        }

        public void CompletarCadastroPessoaJuridica(ClientePessoaJuridica cliente, string cnpj, string razaoSocial, string nomeFantasia, string inscricaoEstadual)
        {
            cliente.SetNomeFantasia(nomeFantasia);
            cliente.SetCnpj(cnpj);
            cliente.SetInscricaoEstadual(inscricaoEstadual);
            cliente.SetRazaoSocial(razaoSocial);
            clientesPessoaJuridicaRepositorio.Atualizar(cliente);
            throw new NotImplementedException();
        }

        public Cliente Validar(int codigoCliente)
        {
            var cliente = clientesRepositorio.Recuperar(codigoCliente);

            if(cliente is null)
            {
                throw new ArgumentException("Cliente não existe");
            }
            return cliente;
        }

         public ClientePessoaFisica ValidarPessoaFisica(int codigoCliente)
        {
            ClientePessoaFisica cliente =  clientesPessoaFisicaRepositorio.Recuperar(codigoCliente);

            if(cliente is null)
            {
                throw new ArgumentException("Cliente não existe");
            }
            return cliente;
        }

        public ClientePessoaJuridica ValidarPessoaJuridica(int codigoCliente)
        {
            ClientePessoaJuridica cliente = clientesPessoaJuridicaRepositorio.Recuperar(codigoCliente);

            if(cliente is null)
            {
                throw new ArgumentException("Cliente não existe");
            }
            return cliente;
        }
        public bool VerificarCadastroPessoaFisica(ClientePessoaFisica cliente)
        {
            if(cliente.Nome is null)
                return false;
            if(cliente.Telefone is null)
                return false;
            if(cliente.SobreNome is null)
                return false;
            if(cliente.Cpf is null)
                return false;
            return true;
        }

        public bool VerificarCadastroPessoaJuridica(ClientePessoaJuridica cliente)
        {
            if(cliente.RazaoSocial is null)
                return false;
            if(cliente.InscricaoEstadual is null)
                return false;
            if(cliente.NomeFantasia is null)
                return false;
            if(cliente.Cnpj is null)
                return false;
            return true;
        }
    }
}