using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pedidos.Entidades;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Entidades
{
    public class Pagamento
    {
        public virtual int Id { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual IList<TipoPagamento> Pagamentos { get; protected set; }
        public virtual Pedido Pedido { get; protected set; }
        protected Pagamento()
        {  

        }

        public Pagamento(decimal valor, IList<TipoPagamento> pagamentos, Pedido pedido)
        {
            SetValor(valor);
            SetListaPagamentos(pagamentos);
            SetPedido(pedido);
        }

        public virtual void SetValor(decimal valor)
        {
            if (valor <= 0) throw new Exception("Valor de pagamento inválido");
            this.Valor = valor;
        }

        public virtual void SetListaPagamentos(IList<TipoPagamento> pagamentos)
        {
            if (pagamentos is null) throw new Exception("Pagamento precisa de um tipo de pagamento"); 
            this.Pagamentos = pagamentos;
        }

        public virtual void SetPedido(Pedido pedido)
        {
            if (pedido is null) throw new Exception("Pedido invalido");
            this.Pedido = pedido;
        }
    }
}