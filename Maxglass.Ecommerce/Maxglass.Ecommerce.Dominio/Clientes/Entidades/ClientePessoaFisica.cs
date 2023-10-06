using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Clientes.Entidades
{
    public class ClientePessoaFisica : Cliente
    {
        public virtual string? Nome {get; protected set;}
        public virtual string? SobreNome {get; protected set;}
        public virtual string? Cpf {get; protected set;}
        public virtual string? Telefone {get; protected set;}

        protected ClientePessoaFisica()
        {
            
        }

        public ClientePessoaFisica(
            string? nome, 
            string? sobreNome, 
            string? cpf, 
            string? telefone,
            string? cep, 
            string? email, 
            string? senha,
            StatusClienteEnum tipo) : base(cep, email, senha, tipo)
        {
            SetNome(nome);
            SetSobreNome(sobreNome);
            SetCpf(cpf);
            SetTelefone(telefone);
        }

        public virtual void SetNome(string? nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome invalido");
            }
            this.Nome = nome;
        }

        public virtual void SetSobreNome(string? sobreNome)
        {
            if (string.IsNullOrEmpty(sobreNome))
            {
                throw new Exception("Sobrenome invalido");
            }
            this.SobreNome = sobreNome;
        }

        public virtual void SetCpf(string? cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                throw new Exception("Cpf invalido");
            }
            this.Cpf = cpf;
        }
   
        public virtual void SetTelefone(string? telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                throw new Exception("Telefone invalido");
            }
            this.Telefone = telefone;
        }
    }
}