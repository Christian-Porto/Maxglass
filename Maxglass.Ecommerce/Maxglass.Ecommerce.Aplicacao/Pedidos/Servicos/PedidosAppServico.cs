using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Pedidos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Requests;
using Maxglass.Ecommerce.DataTransfer.Pedidos.Responses;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using NHibernate;

namespace Maxglass.Ecommerce.Aplicacao.Pedidos.Servicos
{
    public class PedidosAppServico : IPedidosAppServico
    {
        private readonly IMapper mapper;
        private readonly IPedidosServico pedidosServico;
        private readonly IItensPedidoServico itensPedidoServico;
        private readonly IPedidosRepositorio pedidosRepositorio;
        private readonly ISession session;
        private readonly IClientesServico clientesServico;
        private readonly IFretesServico fretesServico;

        public PedidosAppServico(
            IMapper mapper, 
            IPedidosServico pedidosServico, 
            IPedidosRepositorio pedidosRepositorio, 
            IItensPedidoServico itemPedidoServico, 
            ISession session,
            IClientesServico clientesServico,
            IFretesServico fretesServico)
        {
            this.pedidosRepositorio = pedidosRepositorio;
            this.pedidosServico = pedidosServico;
            this.mapper = mapper;
            this.session = session;
            this.clientesServico = clientesServico;
            this.fretesServico = fretesServico;
            this.itensPedidoServico = itemPedidoServico;
            this.fretesServico = fretesServico;
        }


        public PedidoCadastroResponse Inserir(PedidoCadastroRequest request, int codigoCliente)
        {
            var transacao = session.BeginTransaction();
            try
            {   
                Pedido pedido = pedidosServico.Instanciar(request.Cep, request.NumeroEndereco, request.ComplementoEndereco);
                
                Frete frete = fretesServico.Validar(request.IdFrete.Value);
                pedido.SetFrete(frete);

                Cliente cliente = clientesServico.Validar(codigoCliente);
                pedido.SetCliente(cliente);
                
                 var itensPedido = new List<ItemPedido>();

                 foreach (var item in request.itemPedidoRequest)
                 {
                    ItemPedido itemPedido = itensPedidoServico.Instanciar(item.IdProduto.Value, item.Quantidade.Value, pedido);
                    
                     itensPedido.Add(itemPedido);
                 }

                pedido = pedidosServico.CriarPedido(pedido, itensPedido, frete);
                

                var response = mapper.Map<PedidoCadastroResponse>(pedido);

                transacao.Commit();
                
                return response;

            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<PedidoResponse> Listar(int? pagina, int quantidade, int codigoCliente)
        {
            if (pagina.Value <= 0) throw new Exception("Página não especificada");

            IQueryable<Pedido> query = pedidosRepositorio.Query();
            query = query.Where(x=> x.Cliente.Id == codigoCliente);

            PaginacaoConsulta<Pedido> pedidos = pedidosRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<PedidoResponse> responses = mapper.Map<PaginacaoConsulta<PedidoResponse>>(pedidos);

            return responses;
        }

        public PedidoResponse Recuperar(int codigo, int codigoCliente)
        {
            var pedido = pedidosServico.Validar(codigo);
            if(pedido.Cliente.Id !=codigoCliente ){
                throw new Exception("Pedido invalido");
            }
            PedidoResponse response = mapper.Map<PedidoResponse>(pedido);
            return response;
        }

        public void Cancelar(int codigo, int codigoCliente)
        {
            var transacao = session.BeginTransaction();

            try
            {

            Pedido pedido = pedidosServico.Validar(codigo);

            Cliente cliente = clientesServico.Validar(codigoCliente);
                    
            pedidosServico.Cancelar(pedido, cliente);
            
            transacao.Commit();
            }
            catch
            {
            transacao.Rollback();  
            throw;
            }
        }

        public PedidoPagamentoResponse RecuperarValor(int codigo, int codigoCliente)
        {
            var pedido = pedidosServico.Validar(codigo);
            if(pedido.Cliente.Id != codigoCliente );
                throw new Exception("Pedido invalido");
            PedidoPagamentoResponse response = mapper.Map<PedidoPagamentoResponse>(pedido);
            return response;
        }
    }
}