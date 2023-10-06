using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Repositorios;
using Maxglass.Ecommerce.Dominio.Marcas.Servicos;
using NSubstitute;
using Xunit;

namespace Maxglass.Ecommerce.Dominio.Testes.Marcas.Servicos
{
    public class MarcasServicoTestes
    {
        private readonly MarcasServico sut; // SYSTEM UNDER TEST
        private readonly Marca marcaValida; // ENTIDADE MARCA
        private readonly IMarcasRepositorio marcasRepositorio; // MARCA REPOSITORIO PARA SER MOCK, OU SEJA, PARA SIMULAR UM OBJETO

        public MarcasServicoTestes()
        {
             this.marcaValida = Builder<Marca>.CreateNew().Build(); // CRIA UMA INSTANCIA DO OBJETO
             this.marcasRepositorio = Substitute.For<IMarcasRepositorio>(); // REALIZA O MOCK DE IMarcasRepositorio
             this.sut = new MarcasServico(marcasRepositorio); // INSTANCIA MarcasServico
        }

        public class ValidarMetodo : MarcasServicoTestes
        {
            [Fact]
            public void Dado_MarcaNaoEncontrada_Espero_RegraDeNegocioExcecao()
            {
                marcasRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(1)).Should().Throw<Exception>();

            }

            [Fact]
            public void Dado_MarcaEncontrada_Espero_MarcaValida()
            {
                marcasRepositorio.Recuperar(Arg.Any<int>()).Returns(marcaValida);
                sut.Validar(1).Should().BeSameAs(marcaValida);
            }
        }

    }
}