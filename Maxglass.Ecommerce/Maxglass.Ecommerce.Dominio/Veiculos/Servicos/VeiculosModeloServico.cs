using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Repositorios;
using Maxglass.Ecommerce.Dominio.Veiculos.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Veiculos.Servicos
{
    public class VeiculosModeloServico : IVeiculosModeloServico
    {
        private readonly IVeiculoModeloRepositorio veiculosModeloRepositorio;

        public VeiculosModeloServico (IVeiculoModeloRepositorio veiculosModeloRepositorio)
        {
            this.veiculosModeloRepositorio = veiculosModeloRepositorio;
        }
        public VeiculoModelo Validar(int id)
        {
            var veiculo = veiculosModeloRepositorio.Recuperar(id);

            if(veiculo is null)
            {
                throw new Exception("Veículo não existe");
            }
            return veiculo;
        }
    }
}