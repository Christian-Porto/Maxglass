using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Estoques.Requests;
using Maxglass.Ecommerce.DataTransfer.Estoques.Responses;
using Maxglass.Ecommerce.Dominio.Estoques.Entidades;
using Maxglass.Ecommerce.Dominio.Estoques.Repositorios;
using Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Estoques.Servicos
{
    public class EstoquesAppServico : IEstoquesAppServico
    {
        private readonly IEstoquesRepositorio estoquesRepositorio;
        private readonly IEstoquesServico estoquesServico;
        private readonly IMapper mapper;

        public EstoquesAppServico(IEstoquesRepositorio estoquesRepositorio, IEstoquesServico estoquesServico, IMapper mapper)
        {
            this.estoquesRepositorio = estoquesRepositorio;
            this.estoquesServico = estoquesServico;
            this.mapper = mapper;
        }

        public EstoqueResponse Recuperar(int id)
        {
            var estoque = estoquesServico.Validar(id);
            EstoqueResponse response = mapper.Map<EstoqueResponse>(estoque);
            return response;
        }

        public PaginacaoConsulta<EstoqueResponse> Listar(int? pagina, int quantidade, EstoqueListarRequest estoqueRequest)
        {
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");

            IQueryable<Estoque> query = estoquesRepositorio.Query();
            if (estoqueRequest.Cep != null)
            {
                query = query.Where(x => x.Cep.Contains(estoqueRequest.Cep));
            }
            if (estoqueRequest.Descricao != null)
            {
                query = query.Where(x => x.Descricao.Contains(estoqueRequest.Descricao));
            }

            PaginacaoConsulta<Estoque> estoques = estoquesRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<EstoqueResponse> responses = mapper.Map<PaginacaoConsulta<EstoqueResponse>>(estoques);
            return responses;
        }

        public EstoqueQuantidadeResponse RecuperarQuantidadeProduto(int codigoProduto)
        {
             var estoque = estoquesServico.Validar(1);
             int estoqueProdutoQuantidade = estoque.EstoqueProduto.FirstOrDefault(x => x.Produto.Id == codigoProduto).Quantidade.Value;
             EstoqueQuantidadeResponse responses = new EstoqueQuantidadeResponse();
             responses.Quantidade = estoqueProdutoQuantidade;
             return responses;
            
     
        }
    }
}