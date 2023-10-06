using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;

namespace Maxglass.Ecommerce.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriasServico
    {
        Categoria Validar(int id); 
    }
}