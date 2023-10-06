using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Xunit;

namespace Maxglass.Ecommerce.Dominio.Testes.Marcas.Entidades
{
    public class MarcaTestes
    {
        private readonly Marca sut; // System Under Test == Sistema que está sendo testado

        public MarcaTestes()
        {
           sut = Builder<Marca>.CreateNew().Build(); // Criando uma nova instancia do objeto para uso com NBuilder
        }

        public class Construtor
        {

           [Fact]
           public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
           {
            var marca = new Marca("Maxglass");
            marca.Nome.Should().Be("Maxglass");
           }

        }
        public class SetNomeMetodo : MarcaTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_NomeNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>(); // define o nome do objeto e espera uma excessao
            }

            [Fact]

            public void Dado_NomeComMaisDeCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetNome(new string('A', 101))).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNome("Maxglass");
                sut.Nome.Should().Be("Maxglass"); //  define o nome do objeto e espera que o valor seja o mesmo quando consulta a propriedade
                
            }
        }
    }
}