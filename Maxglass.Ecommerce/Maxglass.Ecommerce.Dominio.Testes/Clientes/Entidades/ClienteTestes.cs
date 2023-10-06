using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;
using Xunit;

namespace Maxglass.Ecommerce.Dominio.Testes.Clientes.Entidades
{
    public class ClienteTestes
    {
        private readonly Cliente sut; // System Under Test == Sistema que está sendo testado

        public ClienteTestes()
        {
            sut = Builder<Cliente>.CreateNew().Build(); // Criando uma nova instancia do objeto para uso com NBuilder
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                // Arrange
                
                // Act
                var cliente = new Cliente("29.214-110", "lizzie3611@uorak.com", "YhHjuODn4gz*7bvg6g63", StatusClienteEnum.PessoaFisica);
                // Assert
                cliente.Cep.Should().Be("29214110");
                cliente.Email.Should().Be("lizzie3611@uorak.com");
                cliente.Senha.Should().Be("YhHjuODn4gz*7bvg6g63");
                cliente.Tipo.Should().Be(StatusClienteEnum.PessoaFisica);
            }
        }
        public class SetTipoMetodo : ClienteTestes
        {
            [Fact]
            public void Dado_TipoNaoExistente_Espero_Excecao()
            {
                int tipoInvalidoInt = 3;
                StatusClienteEnum tipoInvalido = (StatusClienteEnum)tipoInvalidoInt;
                sut.Invoking((x => x.SetTipo(tipoInvalido))).Should().Throw<Exception>();
            }
            [Theory]
            [InlineData(StatusClienteEnum.PessoaJuridica)]
            [InlineData(StatusClienteEnum.PessoaFisica)]
            public void Dado_TipoValido_Espero_TipoValido(StatusClienteEnum tipo)
            {
                sut.SetTipo(tipo);
                sut.Tipo.GetType().Should().Be(tipo.GetType());
                sut.Tipo.Should().Be(tipo);
            }
        }
        public class SetSenhaMetodo : ClienteTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_SenhaNulaOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string senha)
            {
                sut.Invoking(x => x.SetSenha(senha)).Should().Throw<Exception>();   //Invoca o metodo SetCep e verifica o retorno de uma excessão
                //Invoking é utilizado quando se espera uma excepiton
            }
            [Fact]
            public void Dado_SenhaValida_Espero_PropriedadesPreenchidas()
            {
                sut.SetSenha("bKfPDf'1hi!J_iaz~.{@");
                sut.Senha.Should().Be("bKfPDf'1hi!J_iaz~.{@");
            }
            [Fact]
            public void Dado_SenhaComNumeroIncorretoDeCaractere_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSenha("bKfPDf'1hi!J_iaz~.{@]")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_SenhaFaltandoCaractereMaiusculo_Espero_TipoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSenha("bkfpdf'1hi!j_iaz~.{@")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_SenhaFaltandoCaractereMinusculo_Espero_TipoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSenha("BKFPDF'1HI!J_IAZ~.{@")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_SenhaFaltandoCaractereEspecial_Espero_TipoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSenha("bKfPDf31hi5J7iaz2BY4")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_SenhaFaltandoCaractereNumerico_Espero_TipoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSenha("bKfPDf'Uhi!J_iaz~.{@")).Should().Throw<Exception>();
            }
        }
        public class SetCepMetodo : ClienteTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string cep)
            {
                sut.Invoking(x => x.SetCep(cep)).Should().Throw<Exception>();   //Invoca o metodo SetCep e verifica o retorno de uma excessão
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
        public class SetEmailMetodo : ClienteTestes
        {
            [Fact]
            public void Dado_EmailValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetEmail("relacionamento@maxglassonline.com.br");
                sut.Email.Should().Be("relacionamento@maxglassonline.com.br");
            }
            [Fact]
            public void Dado_EmailComCaractereEspecial_Espero_EmailComFormatoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetEmail("relacionamento_@maxglassonline.com.br")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_EmailFaltandoCaractereArroba_Espero_EmailComFormatoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetEmail("relacionamentomaxglassonline.com.br")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_EmailFaltandoDominio_Espero_EmailComFormatoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetEmail("relacionamento@.com.br")).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_EmailFaltandoPontoNoFinal_Espero_EmailComFormatoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetEmail("relacionamento@maxglassonline")).Should().Throw<Exception>();
            }
        }
    }
}
