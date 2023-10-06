using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Produtos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Produtos.Farois.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Palhetas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Parachoques.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Requests;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Retrovisores.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Vidros.Responses;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Farois.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Palhetas.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Parachoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGenerico.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosGeral.Repositorios;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Produtos.Vidros.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.ProdutosGeral.ProdutoGeral.Entidades;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {

        private readonly IMapper mapper;
        private readonly IProdutosGeralRepositorio produtosGeralRepositorio;
        private readonly IProdutosGenericoServico<ProdutoGeral> produtosGenericoServico;
        private readonly IFaroisServico faroisServico;
        private readonly IPalhetasServico palhetasServico;
        private readonly IParachoquesServico parachoquesServico;
        private readonly IRetrovisoresServico retrovisoresServico;
        private readonly IProdutosBaseServico produtosBaseServico;
        private readonly IVidrosServico vidrosServico;
        private readonly IClientesServico clientesServico;
        private readonly IVeiculosModeloServico veiculosModeloServico;

        public ProdutosAppServico(
            IMapper mapper,
            IProdutosGeralRepositorio produtosGeralRepositorio,
            IProdutosGenericoServico<ProdutoGeral> produtosGenericoServico,
            IClientesServico clientesServico,
            IFaroisServico faroisServico,
            IPalhetasServico palhetasServico,
            IParachoquesServico parachoquesServico,
            IRetrovisoresServico retrovisoresServico,
            IProdutosBaseServico produtosBaseServico,
            IVidrosServico vidrosServico,
            IVeiculosModeloServico veiculosModeloServico)
        {
            this.mapper = mapper;
            this.produtosGeralRepositorio = produtosGeralRepositorio;
            this.produtosGenericoServico = produtosGenericoServico;
            this.clientesServico = clientesServico;
            this.faroisServico = faroisServico;
            this.palhetasServico = palhetasServico;
            this.parachoquesServico = parachoquesServico;
            this.retrovisoresServico = retrovisoresServico;
            this.produtosBaseServico = produtosBaseServico;
            this.vidrosServico = vidrosServico;
            this.veiculosModeloServico = veiculosModeloServico;
        }
        public PaginacaoConsulta<ProdutoBaseResponse> Listar(int? pagina, int quantidade, ProdutoListarRequest produtoListarRequest, int? codigoCliente)
        {
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");

            IQueryable<ProdutoGeral> query = produtosGeralRepositorio.Query().Where(p => p.Situacao != SituacaoProdutoBaseEnum.Inativo);
            if (produtoListarRequest is null)
                throw new Exception();

            if (produtoListarRequest.Tipo != null)
                query = query.Where(p => ((int)p.Tipo) == produtoListarRequest.Tipo.Value);

            if (!string.IsNullOrEmpty(produtoListarRequest.Nome))
                query = query.Where(p => p.Nome.Contains(produtoListarRequest.Nome));

            if (produtoListarRequest.Categoria != null)
                query = query.Where(p => p.Categoria.Id == produtoListarRequest.Categoria.Value);

            if (produtoListarRequest.Aro != null)
                query = query.Where(p => p.Aro.Contains(produtoListarRequest.Aro));

            if (produtoListarRequest.Borda != null)
                query = query.Where(p => p.Borda.Contains(produtoListarRequest.Borda));

            if (produtoListarRequest.Carcaca != null)
                query = query.Where(x => x.Carcaca.Contains(produtoListarRequest.Carcaca));

            if (produtoListarRequest.Friso != null)
                query = query.Where(x => x.Friso == SituacaoFarolFrisoEnum.Possui);

            if (produtoListarRequest.Lente != null)
                query = query.Where(x => x.Lente.Contains(produtoListarRequest.Lente));

            if (produtoListarRequest.Posicao != null)
                query = query.Where(x => x.Posicao.Contains(produtoListarRequest.Posicao));

            if (produtoListarRequest.Material != null)
                query = query.Where(m => m.Material.Contains(produtoListarRequest.Material));

            if (produtoListarRequest.MaterialBorracha != null)
                query = query.Where(m => m.MaterialBorracha.Contains(produtoListarRequest.MaterialBorracha));
            if (produtoListarRequest.AberturaFriso != null)
                query = query.Where(x => x.AberturaFriso == SituacaoParachoqueAberturaFrisoEnum.Possui);

            if (produtoListarRequest.Moldura != null)
                query = query.Where(x => x.Moldura == (produtoListarRequest.Moldura));

            if (produtoListarRequest.FuroEscapamento != null)
                query = query.Where(x => x.FuroEscapamento == SituacaoParachoqueFuroEscapamentoEnum.Possui);

            if (produtoListarRequest.AberturaSpoiler != null)
                query = query.Where(x => x.AberturaSpoiler == SituacaoParachoqueAberturaSpoilerEnum.Possui);

            if (produtoListarRequest.Capa != null)
                query = query.Where(r => r.Capa.Contains(produtoListarRequest.Capa));

            if (produtoListarRequest.PiscaAlerta != null)
                query = query.Where(r => r.PiscaAlerta == SituacaoRetrovisorPiscaAlertaEnum.Possui);

            if (produtoListarRequest.Marca != null)
                query = query.Where(r => r.Marca.Id == produtoListarRequest.Marca.Value);

            if(produtoListarRequest.Categoria != null){
                query = query.Where(r => r.Categoria.Id == produtoListarRequest.Categoria.Value);
            }

            if (produtoListarRequest.SensorPontoCego != null)
                query = query.Where(r => r.SensorPontoCego == SituacaoRetrovisorSensorPontoCegoEnum.Possui);

            if (produtoListarRequest.Faixa != null)
                query = query.Where(p => p.Faixa.Contains(produtoListarRequest.Faixa));

            PaginacaoConsulta<ProdutoGeral> produtos = produtosGeralRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<ProdutoBaseResponse> responses;

            if (codigoCliente != null && codigoCliente != 0)
            {

                Cliente cliente = clientesServico.Validar(codigoCliente.Value);

                IList<ProdutoGeral> produtosAtualizados = produtosGenericoServico.RetornaProdutoComValorAtacado(produtos.Registros, cliente);
                produtos.Registros = produtosAtualizados;
                responses = mapper.Map<PaginacaoConsulta<ProdutoBaseResponse>>(produtos);

            }
            else
            {
                responses = mapper.Map<PaginacaoConsulta<ProdutoBaseResponse>>(produtos);
            }

            return responses;

        }


        public FarolResponse RecuperarFarol(int idProduto, int? codigoCliente)
        {
            Farol farol = faroisServico.Validar(idProduto);

            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);

                farol = faroisServico.ValidarAutenticado(farol, cliente);
            }

            FarolResponse response = mapper.Map<FarolResponse>(farol);
            return response;
        }


        public PalhetaResponse RecuperarPalheta(int id, int? codigoCliente)
        {
            var palheta = palhetasServico.Validar(id);
            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);
                palheta = palhetasServico.ValidarAutenticado(palheta, cliente);
            }

            var response = mapper.Map<PalhetaResponse>(palheta);
            return response;
        }

        public ParachoqueResponse RecuperarParachoque(int id, int? codigoCliente)
        {
            var parachoque = parachoquesServico.Validar(id);

            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);
                parachoque = parachoquesServico.ValidarAutenticado(parachoque, cliente);
            }

            ParachoqueResponse response = mapper.Map<ParachoqueResponse>(parachoque);
            return response;
        }


        public ProdutoBaseResponse RecuperarProdutoBase(int id, int? codigoCliente)
        {
            var produto = produtosBaseServico.Validar(id);

            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);
                produto = produtosBaseServico.ValidarAutenticado(produto, cliente);
            }

            ProdutoBaseResponse response = mapper.Map<ProdutoBaseResponse>(produto);
            return response;
        }

        public RetrovisorResponse RecuperarRetrovisor(int id, int? codigoCliente)
        {
            var retrovisor = retrovisoresServico.Validar(id);

            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);
                retrovisor = retrovisoresServico.ValidarAutenticado(retrovisor, cliente);
            }

            RetrovisorResponse response = mapper.Map<RetrovisorResponse>(retrovisor);
            return response;
        }

        public VidroResponse RecuperarVidro(int id, int? codigoCliente)
        {
            var vidro = vidrosServico.Validar(id);

            if (codigoCliente != null && codigoCliente != 0)
            {
                Cliente cliente = clientesServico.Validar(codigoCliente.Value);
                vidro = vidrosServico.ValidarAutenticado(vidro, cliente);
            }

            VidroResponse response = mapper.Map<VidroResponse>(vidro);
            return response;
        }
    }
}