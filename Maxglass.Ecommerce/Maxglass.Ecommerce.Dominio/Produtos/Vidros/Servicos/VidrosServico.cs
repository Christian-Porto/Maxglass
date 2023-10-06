using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Produtos.Vidros.Servicos
{
    public class VidrosServico : IVidrosServico
    {
        private readonly IVidrosRepositorio vidrosRepositorio;
        private readonly IProdutosGenericoServico<Vidro> produtosGenericoServico;

        public VidrosServico(IVidrosRepositorio vidrosRepositorio, IProdutosGenericoServico<Vidro> produtosGenericoServico)
        {
            this.vidrosRepositorio = vidrosRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
        }
        public Vidro Validar(int id)
        {
            var vidro = vidrosRepositorio.Recuperar(id);
            if (vidro is null)
            {
                throw new Exception("Vidro não existe");
            }
            if (!(vidro.Tipo == TipoProdutoBaseEnum.Vidro))
            {
                throw new Exception("Vidro não encontrado");
            }
            return vidro;
        }

        public Vidro ValidarAutenticado(Vidro vidro, Cliente cliente)
        {
            return produtosGenericoServico.ValidarAutenticado(vidro, cliente);
        }
    }
}