using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Equivalencias.Entidades
{
    public class Equivalencia
    {
        public virtual int Id { get; protected set; }
        public virtual string? Chave { get; protected set; }
        public virtual IList<ProdutoBase>? Produtos { get; protected set; }
        public virtual IList<VeiculoModelo>? Veiculos { get; protected set; }

        protected Equivalencia()
        {
        }
        public Equivalencia(string? chave, IList<ProdutoBase>? produtos /*, IList<Veiculo>? veiculos*/)
        {

            SetChave(chave);
            SetProdutos(produtos);
            //SetVeiculos(veiculos);

        }



        public virtual void SetChave(string? chave)
        {
            if (string.IsNullOrEmpty(chave))
            {
                throw new Exception("A chave não pode ser nula");
            }
            Chave = chave;
        }
        public virtual void SetProdutos(IList<ProdutoBase>? produtos)
        {
            Produtos = produtos;
        }
        public virtual void SetVeiculos(IList<VeiculoModelo>? veiculos)
        {
            Veiculos = veiculos;
        }
    }
}