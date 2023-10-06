// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using FizzWare.NBuilder;
// using FluentAssertions;
// using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
// using Maxglass.Ecommerce.Dominio.Estoques.Servicos.Interfaces;
// using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
// using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;
// using Maxglass.Ecommerce.Dominio.Pedidos.Repositorios;
// using Maxglass.Ecommerce.Dominio.Pedidos.Servicos;
// using Maxglass.Ecommerce.Dominio.Pedidos.Servicos.Interfaces;
// using NSubstitute;
// using Xunit;

// namespace Maxglass.Ecommerce.Dominio.Testes.Pedidos.Servicos
// {
//     public class PedidosServicoTestes
//     {
//         private readonly IPedidosServico sut; // SYSTEM UNDER TEST
//         private readonly Pedido pedidoValido; // ENTIDADE PEDIDO
//         private IList<ItemPedido> itensPedido;
//         private Cliente cliente;
//         private readonly IEstoquesServico estoquesServico;
//         private readonly IItensPedidoServico itensPedidoServico;
//         private readonly IPedidosRepositorio pedidosRepositorio; // PEDIDO REPOSITORIO PARA SER MOCK, OU SEJA, PARA SIMULAR UM OBJETO

//         public PedidosServicoTestes()
//         {
//             this.pedidoValido = Builder<Pedido>.CreateNew().Build(); // INSTANCIA A ENTIDADE COM O NBUILDER

//             this.pedidosRepositorio = Substitute.For<IPedidosRepositorio>(); // INSTANCIA O REPOSITORIO PARA MOCK COM O NSUBISTITUTE
//             itensPedido = Builder<ItemPedido>.CreateListOfSize(3).Build();
//             cliente = Builder<Cliente>.CreateNew().Build();

//             this.sut = new PedidosServico(pedidosRepositorio, estoquesServico, itensPedidoServico); // INSTANCIA O PEDIDOS SERVICO COMO SISTEM UNDER TEST
//         }

//         public class ValidarMetodo : PedidosServicoTestes
//         {
//             [Fact]
//             public void Dado_MarcaNaoEncontrada_Espero_RegraDeNegocioExcecao()
//             {
//                 pedidosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
//                 sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
//             }

//             [Fact]
//             public void Dado_PedidoEncontrado_Espero_PedidoValido()
//             {
//                 pedidosRepositorio.Recuperar(Arg.Any<int>()).Returns(pedidoValido);
//                 sut.Validar(1).Should().BeSameAs(pedidoValido);
//             }
//         }
//         public class InstanciarMetodo : PedidosServicoTestes
//         {
//             [Fact]
//             public void Dado_ParametrosParaCriarPedido_Espero_PedidoInstanciado()
//             {
//                 string cep = "29103090";
//                 string numeroEndereco = "123";
//                 string complementoEndereco = "Casa";
//                 var pedido = sut.Instanciar(cep, numeroEndereco, complementoEndereco);

//                 pedido.Should().NotBeNull();
//                 pedido.Cep.Should().Be(cep);
//                 pedido.NumeroEndereco.Should().Be(numeroEndereco);
//                 pedido.ComplementoEndereco.Should().Be(complementoEndereco);
//             }
//         }
//         public class InserirMetodo : PedidosServicoTestes
//         {
//             [Fact]
//             public void Dado_PedidoValido_Espero_PedidoInserido()
//             {
//                 pedidosRepositorio.Inserir(Arg.Any<Pedido>()).Returns(pedidoValido);

//                 var pedido = sut.CriarPedido(pedidoValido, itensPedido);

//                 pedidosRepositorio.Received(1).Inserir(pedidoValido);
//                 pedido.Should().BeOfType<Pedido>();
//                 pedido.Should().Be(pedidoValido);

//             }
//         }
//         public class CancelarMetodo : PedidosServicoTestes
//         {
//             [Theory]
//             [InlineData(SituacaoPedidoEnum.Cancelado)]
//             [InlineData(SituacaoPedidoEnum.SeparandoPedido)]
//             [InlineData(SituacaoPedidoEnum.Entregue)]
//             [InlineData(SituacaoPedidoEnum.Enviado)]
//             public void Dado_ParametrosInvalidosParaCancelarPedido_Espero_Excecao(SituacaoPedidoEnum situacao)
//             {
//                 pedidoValido.SetSituacao(situacao);
//                 sut.Invoking((x => x.Cancelar(pedidoValido, cliente))).Should().Throw<Exception>();
//             }

//             [Fact]
//             public void Dado_ParametrosParaCancelarPedido_Espero_PedidoCancelado()
//             {
//                 pedidoValido.SetSituacao(SituacaoPedidoEnum.AguardandoPagamento);
//                 pedidosRepositorio.Atualizar(Arg.Any<Pedido>()).SetSituacao(SituacaoPedidoEnum.Cancelado);

//                 sut.Cancelar(pedidoValido, cliente);
//                 pedidoValido.Situacao.Should().Be(SituacaoPedidoEnum.Cancelado);
//             }
//         }
//     }
// }