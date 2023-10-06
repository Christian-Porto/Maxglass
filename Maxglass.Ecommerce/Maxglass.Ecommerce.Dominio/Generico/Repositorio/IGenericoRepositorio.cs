using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Utils.Consulta;

namespace Maxglass.Ecommerce.Dominio.Generico.Repositorio
{
    public interface IGenericoRepositorio<T>
    {
        T Recuperar(int id);
        
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int? pagina, int quantidade);

        T Inserir(T entidade);

        T Atualizar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> Query();
    }
}