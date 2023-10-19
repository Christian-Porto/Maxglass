export class ItemPedidoRequest {
  quantidade: number;
  idProduto: number;

  constructor(params: Partial<ItemPedidoRequest>) {
      this.quantidade = params.quantidade || null;
      this.idProduto = params.idProduto || null;
  }
}
