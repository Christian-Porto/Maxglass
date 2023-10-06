using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;

namespace Maxglass.Ecommerce.Dominio.Clientes.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; protected set; }
        public virtual string? Cep { get; protected set; }
        public virtual string? Email { get; protected set; }
        public virtual string? Senha { get; protected set; }
        public virtual StatusClienteEnum Tipo { get; protected set; }
        public virtual IList<ProdutoBase> ProdutosFavoritos {get; protected set;}


        protected Cliente()
        {

        }
        public Cliente(
        string? email,
        string? senha)
        {
            SetEmail(email);
            SetSenha(senha);
        }
        public Cliente(
        string? cep,
        string? email,
        string? senha,
        StatusClienteEnum tipo)
        {
            SetCep(cep);
            SetEmail(email);
            SetSenha(senha);
            SetTipo(tipo);
        }

        public virtual void SetTipo(StatusClienteEnum tipo)
        {
            if (!Enum.IsDefined(tipo))
            {
                throw new Exception("Tipo não existe");
            }
            this.Tipo = tipo;
        }

    
        
        public virtual void SetSenha(string? senha)
        {
              if (string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
              {
                  throw new Exception("Senha nula ou com apenas espaços em branco");
              }
              if (senha.Length < 6 || senha.Length > 20)
              {
                  throw new Exception("Senha com menos de 6 ou mais de 20 caracteres");
              }
              // Verifica se a senha possui pelo menos uma letra maiúscula, uma letra minúscula,
              if (!senha.Any(c => char.IsUpper(c)))
              {
                  throw new Exception("Senha precisa ter pelo menos um caractere maiúsculo");
              }
              if (!senha.Any(c => char.IsLower(c)))
              {
                  throw new Exception("Senha precisa ter pelo menos um caractere minúsculo");
              }
              // um caractere especial e um número
              if (!senha.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
              {
                  throw new Exception("Senha precisa ter pelo menos um caractere especial");
              }
              if (!senha.Any(c => char.IsNumber(c)))
              {
                  throw new Exception("Senha precisa ter pelo menos um caractere numérico");
              }
            this.Senha = senha;
        }


        public virtual void SetSenhaHash(string senhaHash){
            this.Senha = senhaHash;
        }

        public virtual void SetCep(string? cep)
        {
            string cepFormatado = Regex.Replace(cep, @"\W", "");
            if (string.IsNullOrWhiteSpace(cepFormatado))
            {
                throw new Exception("Cep nulo ou com apenas espaços em branco");
            }
            if (cepFormatado.Length > 8 || cepFormatado.Length < 8)
            {
                throw new Exception("Tamanho do cep inválido");
            }
            string regexPattern = @"\D+";
            bool regexTrial = Regex.IsMatch(cepFormatado, regexPattern);
            if (regexTrial)
            {
                throw new Exception("O cep só pode conter caracteres númericos");
            }
            this.Cep = cepFormatado;
        }

        public virtual void SetEmail(string? email)
        {
            string pattern = @"^[a-zA-Z0-9]+@\S+\.com(\.\w+)?$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                throw new Exception("Email com formato invalido");
            }
            this.Email = email;
        }
    }
}
