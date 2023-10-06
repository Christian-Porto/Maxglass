using Maxglass.Ecommerce.Dominio.Clientes.Entidades;
using Maxglass.Ecommerce.Dominio.Fretes.Entidades;
using Maxglass.Ecommerce.Dominio.Pedidos.Enumeradores;
using System.Text.RegularExpressions;
using Maxglass.Ecommerce.Dominio.Clientes.Enumeradores;

namespace Maxglass.Ecommerce.Dominio.Pedidos.Entidades
{
    public class Pedido
    {
        public virtual int Id { get; protected set; }
        public virtual string? Cep { get; protected set; }
        public virtual DateTime DataPedido { get; protected set; }
        public virtual DateTime DataPrevistaEntrega { get; protected set; }
        public virtual decimal? Valor { get; protected set; }
        public virtual SituacaoPedidoEnum Situacao { get; protected set; }
        public virtual DateTime DataPrazo { get; protected set; }
        public virtual string? NumeroEndereco { get; protected set; }
        public virtual string? ComplementoEndereco { get; protected set; }
        public virtual Frete? Frete { get; protected set; }
        public virtual IList<ItemPedido> ItensPedido { get; protected set; }
        public virtual Cliente? Cliente { get; protected set; }
        public virtual decimal? ValorBrutoSemFrete { get; protected set; }
        



        protected Pedido()
        { }

        public Pedido(
            string? cep,
            string? numeroEndereco,
            string? complementoEndereco,
            Frete? frete,
            IList<ItemPedido> itensPedido,
            Cliente cliente)
        {
            SetSituacao(SituacaoPedidoEnum.AguardandoPagamento);
            SetFrete(frete);
            SetDataPedido();
            SetDataPrevistaEntrega();
            SetListaItensPedido(itensPedido);
            SetValorBrutoSemFrete();
            SetValor();
            SetCliente(cliente);
            SetDataPrazo();
            SetCep(cep);
            SetNumeroEndereco(numeroEndereco);
            SetComplementoEndereco(complementoEndereco);
        }



        public Pedido(
            string? cep,
            string? numeroEndereco,
            string? complementoEndereco)
        {

            SetCep(cep);
            SetNumeroEndereco(numeroEndereco);
            SetComplementoEndereco(complementoEndereco);
        }

       

        public virtual void SetListaItensPedido(IList<ItemPedido> itensPedido)
        {
            if (itensPedido is null || itensPedido.Count <= 0) throw new Exception("Pedido precisa de itens");
            this.ItensPedido = itensPedido;
        }

        public virtual void SetCep(string? cep)
        {
            string cepFormatado = Regex.Replace(cep, @"\W", "");

            if (string.IsNullOrWhiteSpace(cepFormatado))
            {
                throw new Exception("Pedido precisa ter um cep");
            }
            if (cepFormatado.Length > 8 || cepFormatado.Length < 8)
            {
                throw new Exception("Tamanho do cep inválido");
            }

            string regexPattern = @"\D+";
            bool regexTrial = Regex.IsMatch(cepFormatado, regexPattern);
            if (regexTrial)
            {
                throw new Exception("O cep só pode conter caracteres númericos");
            }

            this.Cep = cepFormatado;
        }

        public virtual void SetDataPedido()
        {
            DateTime dataPedido = DateTime.UtcNow;
            this.DataPedido = dataPedido;
        }

        public virtual void SetDataPrevistaEntrega()
        {
            const int incrementoDeDias = 7;
            DateTime dataPrevistaEntrega = this.DataPedido.AddDays(incrementoDeDias);
            this.DataPrevistaEntrega = dataPrevistaEntrega;
        }
        public virtual void SetValorBrutoSemFrete()
        {
            decimal valorBrutoSemFrete = ItensPedido.Sum(x => (x.ValorItemPedido.Value));
            if (valorBrutoSemFrete <= 0)
            {
                throw new Exception("Valor não pode ser menor ou igual a zero");
            }
            this.ValorBrutoSemFrete = valorBrutoSemFrete;
        }

        public virtual void SetValor()
        {
            decimal valorCompleto;

            valorCompleto = this.ValorBrutoSemFrete.Value + ItensPedido.Sum(x => x.Produto.ValorAreaProduto.Value) + this.Frete.Valor;

            if (valorCompleto < 50)
            {
                throw new Exception("Valor não pode ser menor do que 50");
            }
            this.Valor = valorCompleto;
        }

        public virtual void SetSituacao(SituacaoPedidoEnum situacao)
        {
            if (!Enum.IsDefined(situacao))
            {
                throw new Exception("Situação não existe");
            }

            this.Situacao = situacao;
        }

        public virtual void SetDataPrazo()
        {
            DateTime dataPrazo = DataPedido;
            const int prazoComum = 5;
            dataPrazo = dataPrazo.AddDays(prazoComum);

            if (Cliente.Tipo == StatusClienteEnum.PessoaJuridica)
            {
                const int valorTetoParaDisconto = 40000;
                const int fatorDeIncrementoDeDias = 3;
                int diasAdicionais = ((int)ValorBrutoSemFrete.Value / valorTetoParaDisconto) * fatorDeIncrementoDeDias;
                if (diasAdicionais > 0)
                    dataPrazo = dataPrazo.AddDays(diasAdicionais);
            }

            this.DataPrazo = dataPrazo;
        }

        public virtual void SetNumeroEndereco(string? numeroEndereco)
        {
            if (string.IsNullOrWhiteSpace(numeroEndereco))
            {
                throw new Exception("Pedido precisa ter um número de endereço");
            }

            this.NumeroEndereco = numeroEndereco;
        }

        public virtual void SetComplementoEndereco(string? complementoEndereco)
        {
            if (string.IsNullOrWhiteSpace(complementoEndereco))
            {
                throw new Exception("Pedido precisa ter um complemento de endereço");
            }

            this.ComplementoEndereco = complementoEndereco;
        }

        public virtual void SetFrete(Frete? frete)
        {
            if (frete is null)
            {
                throw new Exception("Pedido precisa ter um frete");
            }
            this.Frete = frete;
        }

        public virtual void SetCliente(Cliente cliente)
        {
            if (cliente is null)
            {
                throw new Exception("Cliente não pode ser nulo");
            }
            this.Cliente = cliente;
        }
    }
}