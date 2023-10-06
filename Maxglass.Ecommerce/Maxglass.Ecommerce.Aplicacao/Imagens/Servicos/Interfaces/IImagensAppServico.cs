using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;

namespace Maxglass.Ecommerce.Aplicacao.Imagens.Servicos.Interfaces
{
    public interface IImagensAppServico
    {
        ImagemResponse Recuperar(int id);
    }
}