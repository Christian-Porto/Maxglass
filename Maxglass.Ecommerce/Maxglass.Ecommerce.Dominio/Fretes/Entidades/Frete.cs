using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.Fretes.Entidades
{
    public class Frete
    {
        public virtual int Id { get; protected set; }
        public virtual string? Regiao { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        protected Frete()
        {
        }
        public Frete(string regiao, decimal valor)
        {
            SetRegiao(regiao);
            SetValor(valor);

        }
        public virtual void SetRegiao(string? regiao)
        {
            if (string.IsNullOrEmpty(regiao))
            {
                throw new Exception("O frete precisa ter uma região");
            }
            Regiao = regiao;
        }
        public virtual void SetValor(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O frete precisa ter um valor maior que 0");
            }
            Valor = valor;
        }
    }
}