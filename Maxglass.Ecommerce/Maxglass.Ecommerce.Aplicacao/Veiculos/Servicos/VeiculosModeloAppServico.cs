using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Veiculos.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Requests;
using Maxglass.Ecommerce.DataTransfer.Veiculos.Responses;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using Maxglass.Ecommerce.Dominio.Veiculos.Entidades;
using Maxglass.Ecommerce.Dominio.Veiculos.Repositorios;
using Maxglass.Ecommerce.Dominio.Veiculos.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Aplicacao.Veiculos.Servicos
{
    public class VeiculosModeloAppServico : IVeiculosModeloAppServico
    {
        private readonly IMapper mapper;
        private readonly IVeiculosModeloServico veiculosModeloServico;
        private readonly IVeiculoModeloRepositorio veiculosModeloRepositorio;

        public VeiculosModeloAppServico(IMapper mapper, IVeiculosModeloServico veiculosModeloServico,
        IVeiculoModeloRepositorio veiculosModeloRepositorio)
        {
            this.mapper = mapper;
            this.veiculosModeloServico = veiculosModeloServico;
            this.veiculosModeloRepositorio = veiculosModeloRepositorio;
        }
        public PaginacaoConsulta<VeiculoModeloResponse> Listar(int pagina, int quantidade, VeiculoModeloListarRequest veiculoModeloRequest)
        {
            if( pagina <= 0) throw new Exception("Página não encontrada");

            IQueryable<VeiculoModelo> query = veiculosModeloRepositorio.Query();

            if(veiculoModeloRequest.ChaveEquivalencia != null) query = query.Where(m => m.ChaveEquivalencia.Chave.Contains(veiculoModeloRequest.ChaveEquivalencia));

            PaginacaoConsulta<VeiculoModelo> veiculoModelo = veiculosModeloRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<VeiculoModeloResponse> responses = mapper.Map<PaginacaoConsulta<VeiculoModeloResponse>>(veiculoModelo);

            return responses;
        }

        public VeiculoModeloResponse Recuperar(int id)
        {
            var veiculosModelo = veiculosModeloServico.Validar(id);
            VeiculoModeloResponse response = mapper.Map<VeiculoModeloResponse>(veiculosModelo);
            return response;
        }
    }
}