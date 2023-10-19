import { SituacaoEnum } from './../enumeradores/situacao.enum';
export class PedidoResponse {
  id: number;
  cep: string;
  valor: number;
  situacao: SituacaoEnum;
  numeroEndereco: string;
  complementoEndereco: string;
  dataPedido: Date;
  dataPrevistaEntrega: Date;
  dataPrazo: Date;
  frete: any;
  itensPedido: Array<any>;
  isExpanded : boolean;

  constructor(params: Partial<PedidoResponse>) {
      this.id = params.id || 0;
      this.cep = params.cep || null;
      this.valor = params.valor || 0;
      this.situacao = params.situacao || 0;
      this.numeroEndereco = params.numeroEndereco || null;
      this.complementoEndereco = params.complementoEndereco || null;
      this.dataPedido = params.dataPedido || null;
      this.dataPrevistaEntrega = params.dataPrevistaEntrega || null;
      this.dataPrazo = params.dataPrazo || null;
      this.frete = params.frete || null;
      this.itensPedido = params.itensPedido || [];
      this.isExpanded = false;
  }
}

