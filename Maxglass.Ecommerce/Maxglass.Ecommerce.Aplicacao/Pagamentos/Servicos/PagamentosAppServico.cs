using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Pagamentos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pagamentos.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pagamentos.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces;
using NHibernate;

namespace Maxglass.Ecommerce.Aplicacao.Pagamentos.Servicos
{
    public class PagamentosAppServico : IPagamentosAppServico
    {
        private readonly IMapper mapper;
        private readonly IPagamentosServico pagamentosServico;
        private readonly IPagamentosRepositorio pagamentosRepositorio;
        private readonly IPedidosServico pedidosServico;
        private readonly ISession session;
        private readonly IClientesServico clientesServico;

        public PagamentosAppServico(
            IMapper mapper, 
            IPagamentosServico pagamentosServico, 
            IPagamentosRepositorio pagamentosRepositorio,
            IPedidosServico pedidosServico,
            ISession session,
            IClientesServico clientesServico)
        {
            this.mapper = mapper;
            this.pagamentosServico = pagamentosServico;
            this.pagamentosRepositorio = pagamentosRepositorio;
            this.pedidosServico = pedidosServico;
            this.session = session;
            this.clientesServico = clientesServico;
        }

        public PaginacaoConsulta<PagamentoResponse> Listar(
            int? pagina, 
            int quantidade, 
            PagamentoListarRequest pagamentoRequest,
            int idCliente)
        {
            if (pagina.Value <= 0) throw new Exception("Página não especificada");

            

           IQueryable<Pagamento> query = pagamentosRepositorio.Query();

            query = query.Where(p => p.Pedido.Cliente.Id == idCliente);

           if (pagamentoRequest.Pedido != null) query = query.Where(p => p.Pedido.Id == pagamentoRequest.Pedido);

           PaginacaoConsulta<Pagamento> pagamentos = pagamentosRepositorio.Listar(query, pagina, quantidade);
           PaginacaoConsulta<PagamentoResponse> responses = mapper.Map<PaginacaoConsulta<PagamentoResponse>>(pagamentos); 
           return responses; 
        }

        public PagamentoInserirResponse PagarPedido(PagamentoInserirRequest pagamentoRequest, int idCliente)
        {
            var transacao = session.BeginTransaction();
            
            try
            {
                
                var pedido = pedidosServico.Validar(pagamentoRequest.IdPedido);

                var cliente = this.clientesServico.Validar(idCliente);

                var pagamento = mapper.Map<Pagamento>(pagamentoRequest);
                pagamento.SetPedido(pedido);

                pagamento = pagamentosServico.PagarPedido(pagamento, cliente);

                var response = mapper.Map<PagamentoInserirResponse>(pagamento);
                transacao.Commit();

                return response;
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public PagamentoResponse Recuperar(int id, int idCliente)
        {
            var pagamento = pagamentosServico.Validar(id);
            if(pagamento.Pedido.Cliente.Id != idCliente)
                throw new Exception("Cliente invalido");

            PagamentoResponse response = mapper.Map<PagamentoResponse>(pagamento);            
            return response;

        }
    }
}