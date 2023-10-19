export class PedidoListarRequest {
  pagina: number;
  quantidade: number;

  constructor(params: Partial<PedidoListarRequest>) {
      this.pagina = params.pagina || 1;
      this.quantidade = params.quantidade || 10;
  }
}
