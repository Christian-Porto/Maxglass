using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Repositorio;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.Farois.Servicos
{
    public class FaroisServico : IFaroisServico
    {
        private readonly IFaroisRepositorio faroisRepositorio;
        private readonly IProdutosGenericoServico<Farol> produtosGenericoServico;
        public FaroisServico(IFaroisRepositorio faroisRepositorio, IProdutosGenericoServico<Farol> produtosGenericoServico)
        {
            this.faroisRepositorio = faroisRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
        }
        public Farol Validar(int id)
        {
            var farol = faroisRepositorio.Recuperar(id);
            if (farol is null)
            {
                throw new Exception("Esse farol não existe");
            }
            if (!(farol.Tipo == TipoProdutoBaseEnum.Farol))
            {
                throw new Exception("Esse farol não existe");
            }
            return farol;
        }

        public Farol ValidarAutenticado(Farol farol, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(farol, cliente);
        }
    }
}