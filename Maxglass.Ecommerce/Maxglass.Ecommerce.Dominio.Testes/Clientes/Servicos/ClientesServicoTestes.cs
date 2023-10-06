// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using FizzWare.NBuilder;
// using FluentAssertions;
// using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
// using Maxglass.Ecommerce.Dominio.Clientes.Repositorios;
// using Maxglass.Ecommerce.Dominio.Clientes.Servicos;
// using Maxglass.Ecommerce.Dominio.Clientes.Servicos.Interfaces;
// using NSubstitute;
// using Xunit;

// namespace Maxglass.Ecommerce.Dominio.Testes.Clientes.Servicos
// {
//     public class ClientesServicoTestes
//     {
//         private readonly IClientesServico sut; // SYSTEM UNDER TEST
//         private readonly Cliente clienteValido; // ENTIDADE CLIENTE
//         private readonly IClientesRepositorio clientesRepositorio; // CLIENTE REPOSITORIO PARA SER MOCK, OU SEJA, PARA SIMULAR UM OBJETO
//         public ClientesServicoTestes()
//         {
//             this.clienteValido = Builder<Cliente>.CreateNew().Build(); // INSTANCIA A ENTIDADE COM O NBUILDER
//             this.clientesRepositorio = Substitute.For<IClientesRepositorio>(); // INSTANCIA O REPOSITORIO PARA MOCK COM O NSUBISTITUTE
//             this.sut = new ClientesServico(clientesRepositorio); // INSTANCIA CLIENTES SERVICO COMO SYSTEM UNDER TEST
//         }
//         public class ValidarMetodo : ClientesServicoTestes
//         {
//             [Fact]
//             public void Dado_ClienteNaoEncontrado_Espero_RegraDeNegocioExcecao()
//             {
//                 clientesRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
//                 sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();
//             }
//             [Fact]
//             public void Dado_ClienteEncontrado_Espero_ClienteValido()
//             {
//                 clientesRepositorio.Recuperar(Arg.Any<int>()).Returns(clienteValido);
//                 sut.Validar(1).Should().BeSameAs(clienteValido);
//             }
//         }
//     }
// }