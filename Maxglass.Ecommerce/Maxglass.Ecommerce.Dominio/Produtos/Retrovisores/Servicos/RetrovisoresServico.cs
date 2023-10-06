using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Servicos
{
    public class RetrovisoresServico : IRetrovisoresServico
    {
        private readonly IRetrovisoresRepositorio retrovisoresRepositorio;
        private readonly IProdutosGenericoServico<Retrovisor> produtosGenericoServico;

        public RetrovisoresServico(IRetrovisoresRepositorio retrovisoresRepositorio, IProdutosGenericoServico<Retrovisor> produtosGenericoServico)
        {
            this.retrovisoresRepositorio = retrovisoresRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
        }

        public Retrovisor Validar(int id)
        {
            var retrovisor = retrovisoresRepositorio.Recuperar(id);
            if (retrovisor is null)
            {
                throw new Exception("Esse retrovisor não existe");
            }
            if(!(retrovisor.Tipo == TipoProdutoBaseEnum.Retrovisor))
            {
                throw new Exception("Esse retrovisor não existe");
            }

            return retrovisor;
        }

        public Retrovisor ValidarAutenticado(Retrovisor retrovisor, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(retrovisor, cliente);
        }
    }
}