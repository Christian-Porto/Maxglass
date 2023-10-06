using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxglass.Ecommerce.DataTransfer.Produtos.Produtos.Requests
{
    public class ProdutoListarRequest
    {
        public int? Tipo {get; set;}
        public string? Nome {get; set;}
        public int? Categoria {get; set;}
        public virtual string? Aro { get; set; }
        public virtual string? Borda { get; set; }
        public virtual string? Carcaca { get; set; }
        public virtual string? Lente { get; set; }
        public virtual int? Friso { get; set; }
        public virtual string? Posicao { get; set; }
        public string? Material { get; set; }
        public string? MaterialBorracha { get; set; }
        public int? AberturaFriso { get; set; }
        public string? Moldura { get; set; }
        public int? FuroEscapamento { get; set; }
        public int? AberturaSpoiler { get; set; }
        public string? Capa { get; set; }
        public int? PiscaAlerta { get; set; }
        public int? SensorPontoCego { get; set; }
        public string? Faixa { get; set; }
        public int? Marca { get; set; }
        
    }
}