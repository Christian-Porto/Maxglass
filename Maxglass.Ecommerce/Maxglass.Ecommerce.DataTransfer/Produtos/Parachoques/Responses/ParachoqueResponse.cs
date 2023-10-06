using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.DataTransfer.Categorias.Responses;
using Maxglass.Ecommerce.DataTransfer.Imagens.Responses;
using Maxglass.Ecommerce.DataTransfer.Marcas.Responses;
using Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Responses;

namespace Maxglass.Ecommerce.DataTransfer.Produtos.Parachoques.Responses
{
    public class ParachoqueResponse
    {
        public int Id { get; set; }
        public string? Posicao { get; set; }
        public int? AberturaFriso { get; set; }
        public string? Moldura { get; set; }
        public int? FuroEscapamento { get; set; }
        public int? AberturaSpoiler { get; set; }
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