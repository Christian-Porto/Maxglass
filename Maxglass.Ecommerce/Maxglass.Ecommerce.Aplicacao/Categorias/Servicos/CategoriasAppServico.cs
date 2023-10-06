using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maxglass.Ecommerce.Aplicacao.Categorias.Servicos.Interfaces;
using Maxglass.Ecommerce.DataTransfer.Categorias.Requests;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Categorias.Repositorios;
using Maxglass.Ecommerce.Dominio.Categorias.Servicos.Interfaces;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Aplicacao.Categorias.Servicos
{
    public class CategoriasAppServico : ICategoriasAppServico
    {
        private readonly ICategoriasServico categoriasServico;
        private readonly ICategoriasRepositorio categoriasRepositorio;
        private readonly IMapper mapper;

        public CategoriasAppServico(ICategoriasServico categoriasServico, ICategoriasRepositorio categoriasRepositorio, IMapper mapper)
        {
            this.categoriasServico = categoriasServico;
            this.categoriasRepositorio = categoriasRepositorio;
            this.mapper = mapper;
        }

        public CategoriaResponse Recuperar(int id)
        {
            var categoria = categoriasServico.Validar(id);
            CategoriaResponse response = mapper.Map<CategoriaResponse>(categoria);
            return response; 
        }

        public PaginacaoConsulta<CategoriaResponse> Listar(int? pagina, int quantidade, CategoriaListarRequest categoriaRequest)
        { 
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");
            
            IQueryable<Categoria> query = categoriasRepositorio.Query(); 
            
            if (categoriaRequest.Descricao != null)
            {
                query = query.Where(c => c.Descricao.Contains(categoriaRequest.Descricao));
            }

            PaginacaoConsulta<Categoria> categorias = categoriasRepositorio.Listar(query,pagina,quantidade);
            PaginacaoConsulta<CategoriaResponse> responses = mapper.Map<PaginacaoConsulta<CategoriaResponse>>(categorias);
            return responses;
        }
    }
}