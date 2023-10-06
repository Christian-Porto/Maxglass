using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;

namespace Maxglass.Ecommerce.Dominio.Imagens.Entidades
{
    public class Imagem
    {
        public virtual int Id { get; protected set; }
        public virtual string? Url { get; protected set; }
        protected Imagem()
        {
        }
    }
}