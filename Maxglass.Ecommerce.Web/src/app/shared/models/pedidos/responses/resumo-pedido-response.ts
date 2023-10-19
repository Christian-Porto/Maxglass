import { ItemPedidoResponse } from './../../../../pedidos/models/pedido-carrinho.response';

export class ResumoPedidoResponse {
  valor : number;
  cep : string;
  numeroEndereco : string;
  complementoEndereco: string;
  frete : any;
  itensPedido : ItemPedidoResponse[];
}
