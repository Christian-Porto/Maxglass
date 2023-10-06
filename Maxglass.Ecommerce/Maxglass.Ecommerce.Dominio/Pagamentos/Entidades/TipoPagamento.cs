using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pagamentos.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Entidades
{
    public class TipoPagamento
    {
        public virtual int Id { get; protected set; }
        public virtual TiposPagamentoEnum Tipo { get; protected set; }
        public virtual decimal ValorParcela { get; protected set; }
        public virtual int Parcela { get; protected set; }

        protected TipoPagamento()
        {  }

        public TipoPagamento(
            TiposPagamentoEnum tipo, 
            decimal valorParcela, 
            int parcela)
        {
            SetTipo(tipo); 
            SetValorParcela(valorParcela);
            SetParcela(parcela);
        }

        public virtual void SetTipo(TiposPagamentoEnum tipo)
        {
            this.Tipo = tipo;
        }

        public virtual void SetValorParcela(decimal valorParcela)
        {
            if (valorParcela <= 0) throw new Exception("Valor de parcela inválido");
            this.ValorParcela = valorParcela;
        }

        public virtual void SetParcela(int parcela)
        {
            if (parcela <= 0) throw new Exception("Parcela não pode ter valor menor que 0");
            this.Parcela = parcela;
        }


    }
}