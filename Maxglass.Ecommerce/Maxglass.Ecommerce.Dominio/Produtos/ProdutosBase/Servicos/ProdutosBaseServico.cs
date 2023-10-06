using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Servicos
{
    public class ProdutosBaseServico : IProdutosBaseServico
    {
        private readonly IProdutosBaseRepositorio produtosBaseRepositorio;
        private readonly IProdutosGenericoServico<ProdutoBase> produtosGenericoServico;

        public ProdutosBaseServico(IProdutosBaseRepositorio produtosBaseRepositorio, IProdutosGenericoServico<ProdutoBase> produtosGenericoServico)
        {
            this.produtosBaseRepositorio = produtosBaseRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;

        }

        public ProdutoBase Instanciar(TipoProdutoBaseEnum tipo, string? nome, decimal altura, decimal profundidade, decimal largura, decimal valor,
         SituacaoProdutoBaseEnum status, IList<Imagem>? imagens, Marca? marca, Categoria? categoria, Equivalencia? chaveEquivalencia)
        {
            ProdutoBase produto = new ProdutoBase(tipo, nome, altura, profundidade, largura, valor, status, imagens, marca, categoria, chaveEquivalencia);
            return produto;
        }

        public ProdutoBase Validar(int id)
        {
            var produto = produtosBaseRepositorio.Recuperar(id);
            if (produto is null)
            {
                throw new Exception("Produto nao existe");
            }
            return produto;
        }

        public ProdutoBase ValidarAutenticado(ProdutoBase produtoBase, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(produtoBase, cliente);

        }
    }
}