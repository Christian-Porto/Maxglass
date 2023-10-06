using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Categorias.Repositorios;
using Maxglass.Ecommerce.Dominio.Categorias.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Categorias.Servicos
{
    public class CategoriasServico : ICategoriasServico
    {
        private readonly ICategoriasRepositorio categoriasRepositorio;

        public CategoriasServico(ICategoriasRepositorio categoriasRepositorio)
        {
            this.categoriasRepositorio = categoriasRepositorio;
        }
        public Categoria Validar(int id)
        {
            var categoria = categoriasRepositorio.Recuperar(id);
            if (categoria is null)
            {
                throw new Exception("Essa categoria não existe");
            }
            return categoria;
        }
    }
}