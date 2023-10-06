using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Categorias.Entidades;
using Maxglass.Ecommerce.Dominio.Equivalencias.Entidades;
using Maxglass.Ecommerce.Dominio.Imagens.Entidades;
using Maxglass.Ecommerce.Dominio.Marcas.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Entidades;
using Maxglass.Ecommerce.Dominio.Produtos.ProdutosBase.Enumeradores;
using Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Produtos.Retrovisores.Entidades
{
    public class Retrovisor : ProdutoBase
    {
        public virtual string? Capa { get; protected set; }
        public virtual string? Carcaca { get; protected set; }
        public virtual string? Lente { get; protected set; }
        public virtual SituacaoRetrovisorPiscaAlertaEnum? PiscaAlerta { get; protected set; }
        public virtual SituacaoRetrovisorSensorPontoCegoEnum? SensorPontoCego { get; protected set; }
    

        protected Retrovisor()
        {   }

        public Retrovisor(
            string? capa,
            string? carcaca, 
            string? lente, 
            SituacaoRetrovisorPiscaAlertaEnum? piscaAlerta, 
            SituacaoRetrovisorSensorPontoCegoEnum? sensorPontoCego,
            TipoProdutoBaseEnum tipo,
            string? nome, 
            decimal altura, 
            decimal profundidade, 
            decimal largura, 
            decimal valor, 
            SituacaoProdutoBaseEnum status,
            IList<Imagem>? imagens, 
            Marca? marca, 
            Categoria? categoria, 
            Equivalencia? chaveEquivalencia) : base(
                tipo, 
                nome, 
                altura, 
                profundidade, 
                largura, 
                valor, 
                status, 
                imagens, 
                marca, 
                categoria,
                chaveEquivalencia) 
        {
            SetCapa(capa);
            SetCarcaca(carcaca);
            SetLente(lente);
            SetPiscaAlerta(piscaAlerta);
            SetSensorPontoCego(sensorPontoCego);
        }

        public virtual void SetCapa(string? capa)
        {
            if (string.IsNullOrEmpty(capa))
            {
                throw new Exception("O produto precisa ter uma capa");
            }

            this.Capa = capa;
        }

        public virtual void SetCarcaca(string? carcaca)
        {
            if(string.IsNullOrEmpty(carcaca))
            {
                throw new Exception("O produto precisa ter uma carcaça");
            }

            this.Carcaca = carcaca;
        }

        public virtual void SetLente(string? lente)
        {
            if(string.IsNullOrEmpty(lente))
            {
                throw new Exception("O produto precisa ter uma lente"); 
            }

            this.Lente = lente;
        }

        public virtual void SetPiscaAlerta(SituacaoRetrovisorPiscaAlertaEnum? piscaAlerta)
        {
            if(!piscaAlerta.HasValue)
            {
                throw new Exception("O pisca alerta não pode ser nulo");
            }

            this.PiscaAlerta = piscaAlerta.Value;
        }

        public virtual void SetSensorPontoCego(SituacaoRetrovisorSensorPontoCegoEnum? sensorPontoCego)
        {
            if(!sensorPontoCego.HasValue) 
            {
                throw new Exception("O sensor ponto cego não pode ser nulo");
            }

            this.SensorPontoCego = sensorPontoCego.Value;
        }

      

    }
}