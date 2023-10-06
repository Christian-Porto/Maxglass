using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;

namespace Maxglass.Ecommerce.Dominio.Imagens.Servicos.Interfaces
{
    public interface IImagensServico
    {
        Imagem Validar(int id);
    }
}