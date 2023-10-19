import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ItemPedidoResponse } from '../models/pedido-carrinho.response';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  carrinho$!: Observable<ItemPedidoResponse>;

  constructor() {}

  recuperaItensCarrinho(){
    return JSON.parse(localStorage.getItem("itens") || "[]"); //irá obter e retornar os dados
 }
}

