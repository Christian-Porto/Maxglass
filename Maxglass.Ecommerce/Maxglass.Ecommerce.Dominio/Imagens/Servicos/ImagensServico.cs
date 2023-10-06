using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Repositorios;
using Maxglass.Ecommerce.Dominio.Imagens.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Imagens.Servicos
{
    public class ImagensServico : IImagensServico
    {
        private readonly IImagensRepositorio imagensRepositorio;

        public ImagensServico(IImagensRepositorio imagensRepositorio)
        {
            this.imagensRepositorio = imagensRepositorio;
        }

        public Imagem Validar(int id)
        {
            var imagem = imagensRepositorio.Recuperar(id);
            if (imagem is null)
            {
                throw new Exception("Essa imagem não existe");
            }
            return imagem;
        }
    }
}