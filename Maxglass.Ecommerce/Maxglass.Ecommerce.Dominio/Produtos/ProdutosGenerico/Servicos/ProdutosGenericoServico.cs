using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos
{
    public class ProdutosGenericoServico<T> : IProdutosGenericoServico<T> where T : ProdutoBase
    {
        private readonly IClientesServico clientesServico;

        public ProdutosGenericoServico(IClientesServico clientesServico)
        {
            this.clientesServico = clientesServico;
        }

        public IList<T> RetornaProdutoComValorAtacado(IList<T> produtos, Cliente cliente)
        {
            if (VerificaClientePessoaJuridica(cliente))
            {
                foreach (var produto in produtos)
                {
                    RetornaProdutoComValorAtacado(produto);
                }
            }

            return produtos;
        }

        public T RetornaProdutoComValorAtacado(T produto)
        {
            decimal valorAtacado = CalculaValorAtacadoDoProduto(produto);
            produto.SetValor(valorAtacado);

            return produto;
        }

        public T ValidarAutenticado(T produto, Cliente cliente)
        {
            if (VerificaClientePessoaJuridica(cliente))
            {
                return RetornaProdutoComValorAtacado(produto);
            }
            return produto;
        }
        public bool VerificaClientePessoaJuridica(Cliente cliente)
        {
            if (cliente.Tipo == StatusClienteEnum.PessoaJuridica)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal CalculaValorAtacadoDoProduto(T produto)
        {
            decimal valor = produto.Valor;
            decimal coeficienteAtacado = 0.15m;
            decimal valorAtacado = valor - (valor * coeficienteAtacado);
            decimal valorAtacadoArredondado = Math.Round(valorAtacado, 2);

            return valorAtacadoArredondado;
        }
    }
}