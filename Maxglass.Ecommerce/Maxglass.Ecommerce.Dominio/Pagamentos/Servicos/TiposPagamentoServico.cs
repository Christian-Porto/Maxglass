using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maxglass.Ecommerce.Dominio.Pagamentos.Entidades;
using Maxglass.Ecommerce.Dominio.Pagamentos.Repositorios;
using Maxglass.Ecommerce.Dominio.Pagamentos.Servicos.Interfaces;

namespace Maxglass.Ecommerce.Dominio.Pagamentos.Servicos
{
    public class TiposPagamentoServico : ITiposPagamentoServico
    {
        private readonly ITiposPagamentoRepositorio tiposPagamentoRepositorio;

        public TiposPagamentoServico(ITiposPagamentoRepositorio tiposPagamentoRepositorio)
        {
            this.tiposPagamentoRepositorio = tiposPagamentoRepositorio;
        }
        public TipoPagamento Validar(int id)
        {
            var tipoPagamento = tiposPagamentoRepositorio.Recuperar(id);
            if (tipoPagamento is null)
            {
                throw new Exception("Esse tipo de pagamento não existe");
            }

            return tipoPagamento;
        }
    }
}