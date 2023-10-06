using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Marcas.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Marcas.Requests;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Repositorios;
using Maxglass.Ecommerce.Dominio.Marcas.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Marcas.Servicos
{
    public class MarcasAppServico : IMarcasAppServico
    {
        private readonly IMapper mapper;
        private readonly IMarcasServico marcasServico;
        private readonly IMarcasRepositorio marcasRepositorio;

        public MarcasAppServico(IMapper mapper, IMarcasServico marcasServico, IMarcasRepositorio marcasRepositorio)
        {
            this.mapper = mapper;
            this.marcasServico = marcasServico;
            this.marcasRepositorio = marcasRepositorio;
        }
        public MarcaResponse Recuperar(int id)
        {
            var marca = marcasServico.Validar(id);
            MarcaResponse response = mapper.Map<MarcaResponse>(marca);
            return response;
        }

        public PaginacaoConsulta<MarcaResponse> Listar(int? pagina, int quantidade, MarcaListarRequest marcaRequest)
        {
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");
            
            IQueryable<Marca> query = marcasRepositorio.Query(); 
            
            if (marcaRequest.Nome != null) query = query.Where(m => m.Nome.Contains(marcaRequest.Nome));
         
            PaginacaoConsulta<Marca> marcas = marcasRepositorio.Listar(query,pagina,quantidade);
            PaginacaoConsulta<MarcaResponse> responses = mapper.Map<PaginacaoConsulta<MarcaResponse>>(marcas);
            return responses;
        }
    }
}