using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Repositorios;
using Maxglass.Ecommerce.Infra.Generico;
using NHibernate;

namespace Maxglass.Ecommerce.Infra.Imagens
{
    public class ImagensRepositorio : GenericoRepositorio<Imagem>, IImagensRepositorio
    {
        public ImagensRepositorio(ISession session) : base(session)
        {
        }
    }
}