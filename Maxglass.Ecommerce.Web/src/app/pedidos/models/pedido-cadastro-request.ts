import { ItemPedidoRequest } from './pedido-carrinho-request';

export class PedidoCadastroRequest {
    cep: string;
    numeroEndereco: string;
    complementoEndereco: string;
    idFrete: number;
    itemPedidoRequest: ItemPedidoRequest[];

    constructor(params: Partial<PedidoCadastroRequest>) {
        this.cep = params.cep || null;
        this.numeroEndereco = params.numeroEndereco || null;
        this.complementoEndereco = params.complementoEndereco || null;
        this.idFrete = params.idFrete || null;
        this.itemPedidoRequest = params.itemPedidoRequest || null;
    }
}
