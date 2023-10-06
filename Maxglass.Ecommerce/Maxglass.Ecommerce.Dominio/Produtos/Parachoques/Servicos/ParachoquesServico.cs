using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Servicos
{
    public class ParachoquesServico : IParachoquesServico
    {
        private readonly IParachoquesRepositorio parachoquesRepositorio;
        private readonly IProdutosGenericoServico<Parachoque> produtosGenericoServico;
        public ParachoquesServico(IParachoquesRepositorio parachoquesRepositorio, IProdutosGenericoServico<Parachoque> produtosGenericoServico)
        {
            this.parachoquesRepositorio = parachoquesRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
        }

        public Parachoque Validar(int id)
        {
            var parachoque = parachoquesRepositorio.Recuperar(id);
            if (parachoque is null)
            {
                throw new Exception("Esse parachoque não existe");
            }
            if(!(parachoque.Tipo == TipoProdutoBaseEnum.Parachoque))
            {
                throw new Exception("Esse parachoque não existe");
            }
            return parachoque;
        }

        public Parachoque ValidarAutenticado(Parachoque parachoque, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(parachoque, cliente);
        }
    }
}