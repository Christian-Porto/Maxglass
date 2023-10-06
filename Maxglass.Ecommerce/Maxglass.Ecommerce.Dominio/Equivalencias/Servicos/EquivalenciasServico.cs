using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Repositorios;
using Maxglass.Ecommerce.Dominio.Equivalencias.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Equivalencias.Servicos
{
    public class EquivalenciasServico : IEquivalenciasServico
    {
        private readonly IEquivalenciasRepositorio equivalenciasRepositorio;
        public EquivalenciasServico(IEquivalenciasRepositorio equivalenciasRepositorio)
        {
            this.equivalenciasRepositorio = equivalenciasRepositorio;
        }
        public Equivalencia Validar(int id)
        {
            var equivalencia = equivalenciasRepositorio.Recuperar(id);
            if (equivalencia is null)
            {
                throw new Exception("Essa equivalencia não existe");
            }
            return equivalencia;
        }
    }
}