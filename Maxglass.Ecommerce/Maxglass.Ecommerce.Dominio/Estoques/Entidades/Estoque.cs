using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.Estoques.Entidades
{
    public class Estoque
    {
        public virtual int Id { get; protected set; }
        public virtual string? Cep { get; protected set; }
        public virtual string? Descricao { get; protected set; }
        public virtual IList<EstoqueProduto>? EstoqueProduto { get; protected set; }

        protected Estoque()
        {
            
        }

        public Estoque(string? cep, string? descricao, IList<EstoqueProduto>? estoqueProduto)
        {
            SetCep(cep);
            SetDescricao(descricao);
            SetEstoqueProduto(estoqueProduto);
        }

        public virtual void SetCep(string? cep)
        {
            if (String.IsNullOrEmpty(cep))
            {
                throw new Exception("O campo cep não pode ser nulo");
            }
            this.Cep = cep;
        }

        public virtual void SetDescricao(string? descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new Exception("O campo descricao não pode ser nulo");
            }
            this.Descricao = descricao;
        }

        public virtual void SetEstoqueProduto(IList<EstoqueProduto>? estoqueProduto)
        {
            if (estoqueProduto is null)
            {
                throw new Exception("A lista de estoque produto não pode ser nulo");
            }

            foreach(var element in estoqueProduto)
            {
                if (element is null)
                {
                    throw new Exception("Os elementos de estoque produto não pode ser nulo");
                }
            }
            this.EstoqueProduto = estoqueProduto;
        }
    }
}