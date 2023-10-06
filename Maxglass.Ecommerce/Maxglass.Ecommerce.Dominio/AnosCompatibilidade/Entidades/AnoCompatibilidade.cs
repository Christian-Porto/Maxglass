using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.AnosCompatibilidade.Entidades
{
    public class AnoCompatibilidade
    {
        public virtual int Id { get; protected set; }
        public virtual string? Ano { get; protected set; }
        protected AnoCompatibilidade()
        {
        }
        public AnoCompatibilidade(string? ano)
        {
            SetAno(ano);
        }

        
        public virtual void SetAno(string? ano)
        {
            Ano = ano;
        }
    }
}