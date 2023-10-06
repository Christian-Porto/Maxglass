using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Servicos
{
    public class PalhetasServico : IPalhetasServico
    {
        private readonly IPalhetasRepositorio palhetasRepositorio;
        private readonly IProdutosGenericoServico<Palheta> produtosGenericoServico;

        public PalhetasServico(IPalhetasRepositorio palhetasRepositorio, IProdutosGenericoServico<Palheta> produtosGenericoServico)
        {
            this.palhetasRepositorio = palhetasRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
        }
        public Palheta Validar(int id)
        {
            var palheta = palhetasRepositorio.Recuperar(id);
            if (palheta is null)
            {
                throw new Exception("Palheta nao existe");
            }
            if(!(palheta.Tipo == TipoProdutoBaseEnum.Palheta))
            {
                throw new Exception("Palheta não existe");
            }
            return palheta;
        }

        public Palheta ValidarAutenticado(Palheta palheta, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(palheta, cliente);
        }
    }
}