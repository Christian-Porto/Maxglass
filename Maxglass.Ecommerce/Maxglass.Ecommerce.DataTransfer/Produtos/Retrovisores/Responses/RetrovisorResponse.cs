using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Produtos.Retrovisores.Responses
{
    public class RetrovisorResponse
    {
        public int Id { get;  set; }
        public string? Capa { get; set; }
        public string? Carcaca { get; set; }
        public string? Lente { get; set; }
        public int PiscaAlerta { get; set; }
        public int SensorPontoCego { get; set; }
        public string? Nome {get; set;}
        public decimal Altura {get; set;}
        public decimal Profundidade {get; set;}
        public decimal Largura {get; set;}
        public decimal Valor {get; set;}
        public IList<ImagemResponse>? Imagens {get; set;}
        public MarcaResponse? Marca {get; set;}
        public CategoriaResponse? Categoria {get; set;}
    }
}