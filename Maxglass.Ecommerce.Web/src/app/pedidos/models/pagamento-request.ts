export class PagamentoInserirRequest{
  valor: number;
  pagamentos: any[];
  idPedido: number;

  constructor(params: Partial<PagamentoInserirRequest>){
    this.valor = params.valor || null;
    this.pagamentos = params.pagamentos || null;
    this.idPedido = params.idPedido || null;
  }
}


