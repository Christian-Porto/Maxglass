using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; protected set; }
        public virtual string? Descricao { get; protected set; }

        protected Categoria()
        {  }

        public Categoria(string? descricao)
        {
            SetDescricao(descricao);
        }

        public virtual void SetDescricao(string? descricao)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                throw new Exception("A categoria precisa ter uma descrição");
            }
            this.Descricao = descricao;
        }


    }
}