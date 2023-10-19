export class ItemPedidoResponse {
  quantidade: number;
  produto: any;

  constructor(params: Partial<ItemPedidoResponse>) {
      this.quantidade = params.quantidade || null;
      this.produto = params.produto || null;
  }
}
