using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Enumeradores;
using Maxglass.Ecommerce.Dominio.Pagamentos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pagamentos.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Servicos
{
    public class PagamentosServico : IPagamentosServico
    {
        private readonly IPagamentosRepositorio pagamentosRepositorio;

        public PagamentosServico(IPagamentosRepositorio pagamentosRepositorio)
        {
            this.pagamentosRepositorio = pagamentosRepositorio;
        }

        public Pagamento PagarPedido(Pagamento pagamento, Cliente cliente)
        {
            // if (pagamento.Pedido.Cliente.Id != cliente.Id)
            //     throw new Exception("Pedido inexistente");

            // if (pagamento.Pedido.Situacao != SituacaoPedidoEnum.AguardandoPagamento)
            //     throw new Exception("Pagamento invalido: Pedido não pode ser pago");
            

            // if (((pagamento.Valor) != (pagamento.Pedido.Valor)))
            //     throw new Exception("Pagamento invalido: Valor diferente do pedido");
            
            
            // if (pagamento.Pagamentos.Count > 2)
            //     throw new Exception("Pagamento invalido: É possivel dividir a compra em no maximo dois cartões");
            
            // if(pagamento.Pagamentos.Count > 1)
            //     foreach (var tipoPagamento in pagamento.Pagamentos)
            //     {
            //         if(tipoPagamento.Tipo !=  TiposPagamentoEnum.Cartao )
            //             throw new Exception("Pagamento invalido: O Pagamento só pode ser divido com cartão");
            //     }

            // if (pagamento.Pedido.Cliente.Tipo == StatusClienteEnum.PessoaFisica)
            //     foreach ( var tipoPagamento in pagamento.Pagamentos)
            //     {
            //         if (tipoPagamento.Tipo == TiposPagamentoEnum.Boleto)
            //             throw new Exception("Pagamento invalido: Pagamento em boleto só esta disponivel para pessoa juridica");                        
            //     }
            

            // decimal valorTotal = 0;
            // foreach ( var tipoPagamento in pagamento.Pagamentos)
            // {
            //     valorTotal += (tipoPagamento.ValorParcela * tipoPagamento.Parcela);
            // }

            // if (((int)valorTotal) != ((int)pagamento.Valor))
            //     throw new Exception("Pagamento invalido: Formas de pagamento com valor diferente");
            
        
            pagamento.Pedido.SetSituacao(SituacaoPedidoEnum.SeparandoPedido);
            pagamento = pagamentosRepositorio.Inserir(pagamento);
            return pagamento;
        }

        public Pagamento Validar(int id)
        {
            var pagamento = pagamentosRepositorio.Recuperar(id);
            if (pagamento is null)
            {
                throw new Exception("Esse pagamento não existe");
            }

            return pagamento;
        }
    }
}