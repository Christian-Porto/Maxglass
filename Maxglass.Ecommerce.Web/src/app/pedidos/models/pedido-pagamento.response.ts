export class PedidoPagamentoResponse{
  valor: number;
  frete: any;

  constructor(params: Partial<PedidoPagamentoResponse>){
    this.valor = params.valor || null;
  }
}



