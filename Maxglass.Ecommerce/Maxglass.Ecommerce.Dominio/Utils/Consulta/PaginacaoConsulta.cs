using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.Dominio.Utils.Consulta
{
    public class PaginacaoConsulta<T>
    {
        public int Quantidade { get; set; }
        public IList<T> Registros{get;set;}


        public PaginacaoConsulta(int quantidade, IList<T> registros){
            this.Quantidade = quantidade;
            this.Registros = registros;
        }
        
    }
}