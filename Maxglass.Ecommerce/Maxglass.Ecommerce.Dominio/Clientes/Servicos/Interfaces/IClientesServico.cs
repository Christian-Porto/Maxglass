using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;

namespace Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces
{
    public interface IClientesServico
    {
        Cliente Validar(int codigoCliente);
        ClientePessoaJuridica ValidarPessoaJuridica(int codigoCliente);
        ClientePessoaFisica ValidarPessoaFisica(int codigoCliente);
        bool VerificarCadastroPessoaFisica(ClientePessoaFisica cliente);
        bool VerificarCadastroPessoaJuridica(ClientePessoaJuridica cliente);
        void CompletarCadastroPessoaFisica(ClientePessoaFisica cliente, string nome, string sobrenome, string telefone, string cpf);
        void CompletarCadastroPessoaJuridica(ClientePessoaJuridica cliente, string cnpj, string razaoSocial, string nomeFantasia, string inscricaoEstadual);

    }
}