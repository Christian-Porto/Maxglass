using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Fretes.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Fretes.Requests;
using Maxglass.Ecommerce.DataTransfer.Fretes.Responses;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Repositorios;
using Maxglass.Ecommerce.Dominio.Fretes.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;
using ISession = NHibernate.ISession;

namespace Maxglass.Ecommerce.Aplicacao.Fretes.Servicos
{
    public class FretesAppServico : IFretesAppServico
    {
        private readonly IFretesServico fretesServico;
        private readonly IFretesRepositorio fretesRepositorio;
        private readonly IMapper mapper;

        public FretesAppServico(IFretesServico fretesServico, IFretesRepositorio fretesRepositorio, IMapper mapper)
        {

            this.fretesServico = fretesServico;
            this.fretesRepositorio = fretesRepositorio;
            this.mapper = mapper;
        }
        public PaginacaoConsulta<FreteResponse> Listar(int? pagina, int quantidade, FreteListarRequest freteRequest)
        {
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");
            
            IQueryable<Frete> query = fretesRepositorio.Query();
            if (freteRequest.Regiao != null)
            {
                query = query.Where(f => f.Regiao.Contains(freteRequest.Regiao));
            }
            PaginacaoConsulta<Frete> fretes = fretesRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<FreteResponse> responses = mapper.Map<PaginacaoConsulta<FreteResponse>>(fretes);
            return responses;
        }

        public FreteResponse Recuperar(int id)
        {
            var frete = fretesServico.Validar(id);
            FreteResponse response = mapper.Map<FreteResponse>(frete);
            return response;
        }
    }
}