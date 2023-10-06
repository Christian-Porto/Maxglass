using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Repositorios;
using Maxglass.Ecommerce.Dominio.Marcas.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Marcas.Servicos
{
    public class MarcasServico : IMarcasServico
    {
        private readonly IMarcasRepositorio marcasRepositorio;

        public MarcasServico(IMarcasRepositorio marcasRepositorio)
        {
            this.marcasRepositorio = marcasRepositorio;
        }
        public Marca Validar(int id)
        {
            var marca = marcasRepositorio.Recuperar(id);
            if (marca is null)
            {
                throw new Exception("Essa marca não existe");
            }
            return marca;
        }
    }
}