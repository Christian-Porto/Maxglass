using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Repositorios;
using Maxglass.Ecommerce.Dominio.Fretes.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Fretes.Servicos
{
    public class FretesServico : IFretesServico
    {
        private readonly IFretesRepositorio fretesRepositorio;
        public FretesServico(IFretesRepositorio fretesRepositorio)
        {
            this.fretesRepositorio = fretesRepositorio;
        }
        public Frete Validar(int id)
        {
            var frete = fretesRepositorio.Recuperar(id);
            if(frete is null)
            {
                throw new Exception("Esse frete não existe!");
            }
            return frete;
        }
    }
}