using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Xunit;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;
using FizzWare.NBuilder.Generators;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using NSubstitute;

namespace Maxglass.Ecommerce.Dominio.Testes.Pedidos.Entidades
{
    public class PedidoTestes
    {
        private readonly Pedido sut; // System Under Test == Sistema que está sendo testado


        private ProdutoBase produtoBase { get; set; }
        private ItemPedido itensPedido { get; set; }
        private Frete frete { get; set; }






        public PedidoTestes()
        {
            sut = Builder<Pedido>.CreateNew().Build();          //Criando uma nova instancia do objeto para uso com NBuilder
            this.itensPedido = Substitute.For<ItemPedido>();    //Entidades mockadas para facilitar os testes
            this.produtoBase = Substitute.For<ProdutoBase>();   //Entidades mockadas para facilitar os testes
            this.frete = Substitute.For<Frete>();               //Entidades mockadas para facilitar os testes
        }

        public class Construtor : PedidoTestes
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Arrange
                frete.Valor.Returns(50m);
                decimal valorItemPedido = 5;
                produtoBase.ValorAreaProduto.Returns(10m);
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                itensPedido.ValorItemPedido.Returns(valorItemPedido);
                itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);

                var cliente = Builder<Cliente>.CreateNew().Build();

                // Act
                var pedido = new Pedido("29101080", "123", "Perto da rua do mario", frete, listaItemPedido, cliente);
                // Assert
                pedido.DataPrazo.Should().HaveYear(2022);
                pedido.Cep.Should().Be("29101080");
                pedido.NumeroEndereco.Should().Be("123");
                pedido.ComplementoEndereco.Should().Be("Perto da rua do mario");
                pedido.Frete.Should().Be(frete);
                pedido.ItensPedido.Count.Should().Be(1);
                pedido.Cliente.Should().Be(cliente);
            }

        }

        public class SetCepMetodo : PedidoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string cep)
            {
                sut.Invoking(x => x.SetCep(cep)).Should().Throw<Exception>(); //Invoca o metodo SetCep e verifica o retorno de uma excessão
                //Invoking é utilizado quando se espera uma excepiton
            }

            [Fact]
            public void Dado_CepValidoComCaracteresEspeciais_Espero_PropriedadesPreenchidas()
            {
                sut.SetCep("29.103-980");
                sut.Cep.Should().Be("29103980");
            }

            [Fact]
            public void Dado_CepValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetCep("29103980");
                sut.Cep.Should().Be("29103980");
            }

            [Fact]
            public void Dado_NomeComMaisDeOitoCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetCep(new string('1', 9))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeComMenosDeOitoCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetCep(new string('1', 7))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_CaracteresNaoNumericos_Espero_TipoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetCep("29.103-a00")).Should().Throw<Exception>();
            }
        }

        public class SetValorMetodo : PedidoTestes
        {
            [Fact]
            public void Quando_ValorTotalMenorQue50_Espero_AtributoObrigatorioExcecao()
            {

                this.frete.Valor.Returns(3m);
                decimal valorItemPedido = 5m;
                this.produtoBase.ValorAreaProduto.Returns(10m);
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                this.itensPedido.ValorItemPedido.Returns(valorItemPedido);
                this.itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);
                sut.SetListaItensPedido(listaItemPedido);
                sut.SetFrete(frete);
                sut.SetValorBrutoSemFrete();

                sut.Invoking((x => x.SetValor())).Should().Throw<Exception>();

            }
            [Fact]
            public void Quando_ValorTotalMaiorQue50_Espero_AtributoValido()
            {
                this.frete.Valor.Returns(3m);
                decimal valorItemPedido = 50m;
                this.produtoBase.ValorAreaProduto.Returns(10m);
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                this.itensPedido.ValorItemPedido.Returns(valorItemPedido);
                this.itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);
                sut.SetListaItensPedido(listaItemPedido);
                sut.SetFrete(frete);
                sut.SetValorBrutoSemFrete();

                sut.SetValor();
                sut.Valor.Should().BeGreaterThan(50);
            }
        }
        public class SetDataPedidoMetodo : PedidoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_DataValida()
            {
                DateTime dataAtual = DateTime.UtcNow;
                sut.SetDataPedido();
                sut.DataPedido.Should().HaveYear(dataAtual.Year);
                sut.DataPedido.Should().HaveMonth(dataAtual.Month);
                sut.DataPedido.Should().HaveDay(dataAtual.Day);
            }
        }
        public class SetDataPrevistaEntregaMetodo : PedidoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_DataValida()
            {
                const int incrementoDeDias = 7;
                sut.SetDataPedido();
                sut.SetDataPrevistaEntrega();
                sut.DataPrevistaEntrega.Should().HaveDay(sut.DataPedido.Day + incrementoDeDias);

            }
        }
        public class SetValorBrutoSemFreteMetodo : PedidoTestes
        {

            [Fact]
            public void Quando_MetodoForChamado_Espero_ValorValido()
            {
                decimal valorItemPedido = 5m;
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                this.itensPedido.ValorItemPedido.Returns(valorItemPedido);
                this.itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);
                sut.SetListaItensPedido(listaItemPedido);

                const decimal valorEsperado = 5m;

                sut.SetValorBrutoSemFrete();

                sut.ValorBrutoSemFrete.Should().NotBeNull();
                sut.ValorBrutoSemFrete.Should().NotBe(0);
                sut.ValorBrutoSemFrete.Should().Be(valorEsperado);

            }
        }
        public class SetSituacaoMetodo : PedidoTestes
        {

            [Fact]
            public void Dado_SituacaoNaoExistente_Espero_Excecao()
            {
                int situacaoInvalidaInt = 6;
                SituacaoPedidoEnum situacaoInvalida = (SituacaoPedidoEnum)situacaoInvalidaInt;
                sut.Invoking((x => x.SetSituacao(situacaoInvalida))).Should().Throw<Exception>();
            }

            [Theory]
            [InlineData(SituacaoPedidoEnum.AguardandoPagamento)]
            [InlineData(SituacaoPedidoEnum.Cancelado)]
            [InlineData(SituacaoPedidoEnum.Entregue)]
            [InlineData(SituacaoPedidoEnum.Enviado)]
            [InlineData(SituacaoPedidoEnum.SeparandoPedido)]
            public void Dado_SituacaoValida_Espero_SituacaoValida(SituacaoPedidoEnum situacao)
            {
                sut.SetSituacao(situacao);
                sut.Situacao.GetType().Should().Be(situacao.GetType());
                sut.Situacao.Should().Be(situacao);
            }
        }
        public class SetDataPrazoMetodo : PedidoTestes
        {

            [Fact]
            public void Quando_ValorDoPedidoSemFreteForMaiorQue40Mil_Espero_DataValida()
            {
                //Arrange
                decimal valorItemPedido = 45000m;
                var cliente = Builder<Cliente>.CreateNew().Build();
                cliente.SetTipo(StatusClienteEnum.PessoaJuridica);
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                this.itensPedido.ValorItemPedido.Returns(valorItemPedido);
                this.itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);
                sut.SetListaItensPedido(listaItemPedido);
                sut.SetValorBrutoSemFrete();
                sut.SetCliente(cliente);
                sut.SetDataPedido();
                const int prazoComum = 5;
                const int valorTetoParaDisconto = 40000;
                const int fatorDeIncrementoDeDias = 3;
                int diasAdicionais = ((int)sut.ValorBrutoSemFrete.Value / valorTetoParaDisconto) * fatorDeIncrementoDeDias;
                //Act
                sut.SetDataPrazo();
                //Assert
                sut.DataPrazo.Should().Be(sut.DataPedido.AddDays(prazoComum + diasAdicionais));

            }

            [Theory]
            [InlineData(StatusClienteEnum.PessoaFisica)]
            [InlineData(StatusClienteEnum.PessoaJuridica)]
            public void Quando_MetodoForChamadoParaClienteValido_Espero_DataValida(StatusClienteEnum tipoCliente)
            {
                decimal valorItemPedido = 45000m;
                var cliente = Builder<Cliente>.CreateNew().Build();
                cliente.SetTipo(tipoCliente);
                IList<ItemPedido> listaItemPedido = new List<ItemPedido>();
                this.itensPedido.ValorItemPedido.Returns(valorItemPedido);
                this.itensPedido.Produto.Returns(produtoBase);
                listaItemPedido.Add(itensPedido);
                sut.SetListaItensPedido(listaItemPedido);
                sut.SetValorBrutoSemFrete();
                sut.SetCliente(cliente);
                sut.SetDataPedido();
                const int prazoComum = 5;

                sut.SetDataPrazo();

                if (cliente.Tipo == StatusClienteEnum.PessoaJuridica)
                {
                    const int valorTetoParaDisconto = 40000;
                    const int fatorDeIncrementoDeDias = 3;
                    int diasAdicionaisEsperados = ((int)sut.ValorBrutoSemFrete.Value / valorTetoParaDisconto) * fatorDeIncrementoDeDias;
                    int prazoTotalEsperado = diasAdicionaisEsperados + prazoComum;
                    sut.DataPrazo.Should().Be(sut.DataPedido.AddDays(prazoTotalEsperado));
                }
                else
                {
                    sut.DataPrazo.Should().Be(sut.DataPedido.AddDays(prazoComum));
                }
            }
        }
        public class SetNumeroEnderecoMetodo : PedidoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_NumeroEnderecoNuloOuVazio_Espero_Execao(string numeroEndereco)
            {
                sut.Invoking((x => x.SetNumeroEndereco(numeroEndereco))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NumeroEnderecoValido_Espero_PropriedadeValida()
            {
                string numeroEnderecoValido = "123";
                sut.SetNumeroEndereco(numeroEnderecoValido);
                sut.NumeroEndereco.Should().NotBeNullOrWhiteSpace();
                sut.NumeroEndereco.Should().Be(numeroEnderecoValido);
            }
        }
        public class SetComplementoEnderecoMetodo : PedidoTestes
        {

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_ComplementoEnderecoNuloOuVazio_Espero_Execao(string complementoEndereco)
            {
                sut.Invoking((x => x.SetComplementoEndereco(complementoEndereco))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ComplementoEnderecoValido_Espero_PropriedadeValida()
            {
                string complementoEnderecoValido = "Proximo a cantina avohai";
                sut.SetComplementoEndereco(complementoEnderecoValido);
                sut.ComplementoEndereco.Should().NotBeNullOrWhiteSpace();
                sut.ComplementoEndereco.Should().Be(complementoEnderecoValido);
            }

        }
        public class SetFreteMetodo : PedidoTestes
        {

            [Theory]
            [InlineData(null)]
            public void Dado_FreteNulo_Espero_Excecao(Frete frete)
            {
                sut.Invoking((x => x.SetFrete(frete))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_FreteValido_Espero_PropriedadeValida()
            {
                Frete freteValido = Builder<Frete>.CreateNew().Build();

                sut.SetFrete(freteValido);

                sut.Frete.Should().NotBeNull();
                sut.Frete.GetType().Should().Be(freteValido.GetType());
                sut.Frete.Should().Be(freteValido);
            }
        }

        public class SetClienteMetodo : PedidoTestes
        {

            [Theory]
            [InlineData(null)]
            public void Dado_ClienteNulo_Espero_Excecao(Cliente cliente)
            {
                sut.Invoking((x => x.SetCliente(cliente))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ClienteValido_Espero_PropriedadeValida()
            {
                Cliente cliente = Builder<Cliente>.CreateNew().Build();

                sut.SetCliente(cliente);

                sut.Cliente.Should().NotBeNull();
                sut.Cliente.GetType().Should().Be(cliente.GetType());
                sut.Cliente.Should().Be(cliente);
            }
        }
    }
}
