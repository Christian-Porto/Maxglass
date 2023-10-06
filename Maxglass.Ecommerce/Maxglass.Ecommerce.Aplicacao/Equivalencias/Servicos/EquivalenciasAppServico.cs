using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Equivalencias.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Equivalencias.Reponses;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Repositorios;
using Maxglass.Ecommerce.Dominio.Equivalencias.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Aplicacao.Equivalencias.Servicos
{
    public class EquivalenciasAppServico : IEquivalenciasAppServico
    {
        private readonly IEquivalenciasServico equivalenciasServico;
        private readonly IEquivalenciasRepositorio equivalenciasRepositorio;
        private readonly IMapper mapper;

        public EquivalenciasAppServico(IEquivalenciasServico equivalenciasServico, IEquivalenciasRepositorio equivalenciasRepositorio, IMapper mapper)
        {
            this.equivalenciasServico = equivalenciasServico;
            this.equivalenciasRepositorio = equivalenciasRepositorio;
            this.mapper = mapper;
        }
        public EquivalenciaResponse Recuperar(int id)
        {
            var equivalencia = equivalenciasServico.Validar(id);
            EquivalenciaResponse response = mapper.Map<EquivalenciaResponse>(equivalencia);
            return response;
        }
    }
}