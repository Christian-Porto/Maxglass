using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.Marcas.Entidades
{
    public class Marca
    {
        public virtual int Id {get; protected set;}
        public virtual string? Nome {get; protected set;}
        protected Marca()
        {
        }

        public Marca(string? nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string? nome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("A marca precisa ter um nome");
            }
            if(nome.Length > 100)
            {
                throw new Exception("O nome não pode ser maior que 100");
            }
            this.Nome = nome;
        }

    }
}