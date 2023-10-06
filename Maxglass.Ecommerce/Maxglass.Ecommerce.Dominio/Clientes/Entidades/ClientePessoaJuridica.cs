using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Clientes.Entidades
{
    public class ClientePessoaJuridica : Cliente
    {
        public virtual string? Cnpj {get; protected set;}
        public virtual string? RazaoSocial {get; protected set;}
        public virtual string? InscricaoEstadual {get; protected set;}
        public virtual string? NomeFantasia {get; protected set;}


        protected ClientePessoaJuridica()
        {
        
        }

        public ClientePessoaJuridica(
            string? cnpj, 
            string? razaoSocial, 
            string? inscricaoEstadual, 
            string? nomeFantasia,
            string? cep, 
            string? email, 
            string? senha,
            StatusClienteEnum tipo) : base(cep, email, senha, tipo)
        {
            SetCnpj(cnpj);
            SetRazaoSocial(razaoSocial);
            SetInscricaoEstadual(inscricaoEstadual);
            SetNomeFantasia(nomeFantasia);
        }

        public virtual void SetCnpj(string? cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                throw new Exception("Cnpj invalido");
            }
            this.Cnpj = cnpj;
        }
    
        public virtual void SetRazaoSocial(string? razaoSocial)
        {
            if (string.IsNullOrEmpty(razaoSocial))
            {
                throw new Exception("Razao social invalida"); 
            }
            this.RazaoSocial = razaoSocial;
              
        }

        public virtual void SetInscricaoEstadual(string? inscricaoEstadual)
        {
            if (string.IsNullOrEmpty(inscricaoEstadual))
            {
                throw new Exception("Inscricao estadual invalida"); 
            }
            this.InscricaoEstadual = inscricaoEstadual;
        }

        public virtual void SetNomeFantasia(string? nomeFantasia)
        {
            if (string.IsNullOrEmpty(nomeFantasia))
            {
                throw new Exception("Nome fantasia invalida"); 
            }
            this.NomeFantasia = nomeFantasia;
        }
    }
}